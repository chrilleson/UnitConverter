import { Button, FormControlLabel, Switch } from "@mui/material"
import { ChangeEvent, Fragment, useState } from "react";

import FormGroup from "@mui/material/FormGroup"
import enheterService from "../../services/enheter.service"

export const Enheter = () => {
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
      <Button variant="contained" size="medium">Hämta enheter</Button>
    </>
  );
}