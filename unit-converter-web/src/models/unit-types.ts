export interface UnitType {
  Name: string;
}

export interface UnitModel {
  convertFrom: Unit;
  convertTo: Unit;
}

export interface Unit {
  value?: Number;
  unitType: string;  
}