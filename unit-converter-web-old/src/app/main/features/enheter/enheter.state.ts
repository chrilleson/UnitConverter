import { Injectable } from "@angular/core";
import { Action, NgxsOnInit, Selector, State, StateContext } from "@ngxs/store";
import { Async } from "src/app/decorators";
import { EnheterService } from "./enheter.service";
import { UnitModel } from "./enheter.model";
import { lastValueFrom } from 'rxjs';

@Async()
export class LoadLengthList{
    static readonly type = '[Unit] Loaded length list';
}

@Async()
export class LoadWeightList{
    static readonly type = '[Unit] Loaded weight list';
}

@Async()
export class LoadVolumeList{
    static readonly type = '[Unit] Loaded volume list';
}

export interface UnitStateModel{
    unitsToConvert: UnitModel[],
    length: UnitModel[],
    weight: UnitModel[],
    volume: UnitModel[],
}

@Injectable()
@State<UnitStateModel>({
    name: 'units',
    defaults: {
        unitsToConvert: [],
        length: [],
        weight: [],
        volume: [],
    }
})
export class EnheterState {

    @Selector()
    static unitList(state: UnitStateModel): UnitModel[] {
        state.unitsToConvert = state.length.concat(state.weight.concat(state.volume));
        return state.unitsToConvert.map(x => ({ ...x }));
    }

    constructor(private service: EnheterService) { }

    @Action(LoadLengthList)
    async loadLengthList(ctx: StateContext<UnitStateModel>) {
        ctx.patchState({ });
        const lengthList = await lastValueFrom(this.service.getLength());
        ctx.patchState({ length: lengthList });
    }

    @Action(LoadWeightList)
    async LoadWeightList(ctx: StateContext<UnitStateModel>) {
        ctx.patchState({ });
        const weightList = await lastValueFrom(this.service.getWeight());
        ctx.patchState({ weight: weightList });
    }

    @Action(LoadVolumeList)
    async LoadVolumeList(ctx: StateContext<UnitStateModel>) {
        ctx.patchState({ });
        const volumeList = await lastValueFrom(this.service.getVolume());
        ctx.patchState({ volume: volumeList });
    }
}