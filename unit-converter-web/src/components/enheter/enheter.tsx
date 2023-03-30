import { FormControlLabel, Switch } from "@mui/material"

import FormGroup from "@mui/material/FormGroup"
import { Fragment } from "react";
import enheterService from "../../services/enheter.service"

export const Enheter = () => {
  const unitTypes = enheterService.getUnitTypes();
  
  return (
    <div>
      {!!unitTypes &&
        unitTypes.map((x, i) => {
          return (
            <Fragment key={i}>
              <FormGroup>
                <FormControlLabel control={<Switch name={x} />} label={x} />
              </FormGroup>
            </Fragment>
          );
        })
      }
    </div>
  );
}