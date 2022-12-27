export interface Unit {
    value: number;
    unitType: string;
}

export interface UnitModel {
    convertFrom: Unit;
    convertTo: Unit;
}