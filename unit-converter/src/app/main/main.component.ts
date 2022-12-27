import { ChangeDetectionStrategy, Component } from "@angular/core";
import { Select, Store } from "@ngxs/store";
import { Observable } from "rxjs";
import { UiState, UpdateTheme } from "../states/ui.state";

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MainComponent {

    @Select(UiState.theme) theme$: Observable<string> | undefined;

    constructor(private store: Store) { }

    onToggleChanged(useDarkTheme: boolean): void {
        this.store.dispatch(new UpdateTheme(useDarkTheme ? 'dark-theme' : 'light-theme'))
    }
}