import { OverlayContainer } from '@angular/cdk/overlay';
import { ChangeDetectionStrategy, Component, HostBinding, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Actions, ofActionDispatched, Store } from '@ngxs/store';
import { ActionStatus } from '@ngxs/store/src/actions-stream';
import { filter, takeUntil } from 'rxjs/operators';
import { getSucessfulMessage, hasSuccessDecorator } from './decorators';
import { DestroyService } from './services/destroy.service';
import { DisplayError, UiState } from './states/ui.state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [DestroyService]
})
export class AppComponent implements OnInit {

  title = 'Enhetsomvandlaren';
  overlayElement = this.overlayContainer.getContainerElement();

  @HostBinding('class')
  theme!: string;

  constructor(private store: Store, private actions$: Actions, private overlayContainer: OverlayContainer, private snackBar: MatSnackBar, private destroy$: DestroyService) { }

  ngOnInit(): void {
    this.store.select(UiState.theme)
      .pipe(takeUntil(this.destroy$))
      .subscribe(theme => this.changeTheme(theme));

      this.actions$
        .pipe(filter(({ status, action}) => status === ActionStatus.Successful && hasSuccessDecorator(action)), takeUntil(this.destroy$))
        .subscribe(({ action }) => this.displayMessage(getSucessfulMessage(action), 'success'));

        this.actions$
          .pipe(ofActionDispatched(DisplayError), takeUntil(this.destroy$))
          .subscribe(({ message }) => this.displayMessage(message, 'error', 6000));
  }

  private changeTheme(theme: string): void {
    const currentTheme = this.theme;
    this.overlayElement.classList.remove(currentTheme);
    this.overlayElement.classList.add(theme);
    this.theme = theme;
  }

  private displayMessage(message: string, status: string, duration: number=4000): void {
    this.snackBar.open(message, 'Stäng', {
      horizontalPosition: 'left',
      duration,
      panelClass: [`snackbar-${status}`]
    });
  }
}
