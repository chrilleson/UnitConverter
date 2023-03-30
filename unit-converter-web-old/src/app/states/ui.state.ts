import { Injectable } from "@angular/core";
import { Action, Selector, State, StateContext, NgxsOnInit} from '@ngxs/store';

export class UpdateTheme {
    static readonly type = '[UI] Update theme';
    constructor(public theme: string) { }
}

export class DisplayError {
    static readonly type = '[UI] Display Error';
    constructor(public message: string) { }
}

export interface UiStateModel {
    theme: string;
}

@Injectable()
@State<UiStateModel>({
    name: 'ui',
    defaults: {
        theme: 'dark-theme',
    }
})
export class UiState implements NgxsOnInit {

    @Selector()
    static theme(state: UiStateModel){
        return state.theme;
    }

    ngxsOnInit(ctx: StateContext<UiStateModel>) {
        ctx.patchState({ theme: localStorage.getItem('theme') ?? 'dark-theme'});
    }

    @Action(UpdateTheme)
    updateTheme(ctx: StateContext<UiStateModel>, { theme }: UpdateTheme) {
        ctx.patchState({ theme });
        localStorage.setItem('theme', theme);
    }
}