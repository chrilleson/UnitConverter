import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatToolbarModule } from "@angular/material/toolbar";
import { RouterModule } from "@angular/router";
import { MainComponent } from "./main.component";

const materialModules = [
    MatButtonModule,
    MatSidenavModule,
    MatSlideToggleModule,
    MatIconModule,
    MatToolbarModule,
];

@NgModule({
    declarations: [
        MainComponent
    ],
    imports: [
        ...materialModules,
        CommonModule,
        RouterModule.forChild([{
            path: '', component: MainComponent, children: [
                { path: '', redirectTo: 'enheter', pathMatch: 'full'},
                { path: 'enheter', loadChildren: () => import('./features/enheter/enheter.module').then(x => x.EnheterModule)},
                { path: '*', redirectTo: 'enheter', pathMatch: 'full' },
            ]
        }])
    ]
})
export class MainModule { }