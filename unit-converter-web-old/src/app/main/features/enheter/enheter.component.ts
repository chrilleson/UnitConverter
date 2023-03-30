import { Component } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { EnheterState, LoadLengthList, LoadVolumeList, LoadWeightList } from './enheter.state';
import { UnitModel } from './enheter.model';
import { Observable } from 'rxjs';
import { AbstractControl, FormGroup, FormBuilder, ValidationErrors, ValidatorFn, Validators, FormArray } from '@angular/forms';

@Component({
  selector: 'app-enheter',
  templateUrl: './enheter.component.html',
  styleUrls: ['./enheter.component.css']
})
export class EnheterComponent {

  @Select(EnheterState.unitList) unitList$: Observable<UnitModel[]> | undefined;

  unitsToLoad: string[] = [];
  unitTypes = [
    { name: 'Längd📏', unitTypeName: 'length' },
    { name: 'Vikt🪨', unitTypeName: 'weight' },
    { name: 'Volym🧪', unitTypeName: 'volume' },
  ]
  unitForm = this.fb.group({
    units: [ '', [Validators.required]]
  });

  constructor(private store: Store, private fb: FormBuilder) { }

  onToggleChanged(getUnits: boolean, unitTypeName: string): void {
    getUnits
      ? this.unitsToLoad.push(unitTypeName)
      : this.unitsToLoad = this.unitsToLoad.filter(x => x !== unitTypeName);  
  }

  onClick(): void{
      this.unitsToLoad.forEach(unit => {
        switch (unit) {
          case 'length':
            this.store.dispatch(new LoadLengthList());
            break;
          case 'weight':
            this.store.dispatch(new LoadWeightList());
            break;
          case 'volume':
            this.store.dispatch(new LoadVolumeList());
            break;
          default:
            break;
        }
      });
  }

  onSubmit(){
    this.unitList$?.forEach(units => { 
      let i = 0;     
      units.forEach(unit => {
        let inputElemet = (<HTMLInputElement>document.getElementById(i.toString()));
        let correctValue = unit.convertTo.value.toString();
        i++;
        if(inputElemet.value === correctValue){
          console.log("Correct!", unit.convertTo);
          inputElemet.classList.add("valid");
          return true;
        }
        console.log("Incorrect", unit.convertTo);        
        return false;
      });
    });
  }
}
