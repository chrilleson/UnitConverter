import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from "@angular/material/form-field";
import { MatGridListModule } from "@angular/material/grid-list";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from "@angular/material/menu";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatToolbarModule } from "@angular/material/toolbar";
import { RouterModule } from "@angular/router";
import { NgxsModule } from "@ngxs/store";
import { EnheterComponent } from "./enheter.component";
import { EnheterService } from "./enheter.service";
import { EnheterState } from "./enheter.state";

const materialModules = [
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatGridListModule,
    MatInputModule,
    MatIconModule,
    MatMenuModule,
    MatSidenavModule,
    MatSlideToggleModule,
    MatToolbarModule,
];


@NgModule({
    declarations: [
        EnheterComponent
    ],
    imports: [
        ...materialModules,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NgxsModule.forFeature([EnheterState]),
        RouterModule.forChild([{ path: '', component: EnheterComponent}])
    ],
    providers: [
        { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'outline' }},
        EnheterService
    ]
})
export class EnheterModule { }