import { Button, FormControlLabel, Switch } from "@mui/material"
import { ChangeEvent, Fragment, useState } from "react";

import FormGroup from "@mui/material/FormGroup"
import { UnitModel } from "../../models/unit-types";
import enheterService from "../../services/enheter.service"
import { useAppContext } from "../../contexts/app-context";

export const Enheter = () => {
  const appContext = useAppContext();
  const unitTypes = enheterService.getUnitTypes();
  const [selectedUnits, setSelectedUnits] = useState<string[]>([]);

  const handleOnSelect = (event: ChangeEvent<HTMLInputElement>) => {
    if(event.target.checked){
      setSelectedUnits([...selectedUnits, event.target.value]);
      return;
    }
    const copyValue = selectedUnits;
    const index = copyValue.findIndex(x => x === event.target.value);
    copyValue.splice(index, 1);
    setSelectedUnits([...copyValue]);
  }

  const handleHämtaEnheter = () => {
    const units: UnitModel[] = [];    
    selectedUnits.forEach(selectedUnit => {
      switch(selectedUnit){
        case 'length': 
          enheterService.getLengthUnits().then(response => {
            response.data.forEach(x => units.push(x));
          });
          break;
        case 'weight': 
          enheterService.getWeightUnits().then(response => {
            response.data.forEach(x => units.push(x));
          });
          break;
        case 'volume': 
          enheterService.getVolumeUnits().then(response => {
            response.data.forEach(x => units.push(x));
          });
          break;
        default:
          throw new Error('Unrecognized unit');          
      }
    });

    console.log(units);
    
    appContext.dispatch({
      type: 'ADD_UNITS',
      units: units
    });
  }
  
  return (
    <>
      {!!unitTypes &&
        unitTypes.map((x, i) => {
          return (
            <Fragment key={i}>
              <FormGroup>
                <FormControlLabel control={<Switch name={x.unitTypeName} value={x.unitTypeName} onChange={handleOnSelect} />} label={x.name} />
              </FormGroup>
            </Fragment>
          );
        })
      }
      <Button variant="contained" size="medium" onClick={handleHämtaEnheter}>Hämta enheter</Button>
    </>
  );
}