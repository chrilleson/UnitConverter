import { Box, Button, FilledInput, FormControl, FormGroup, FormHelperText, InputAdornment, Typography } from "@mui/material";
import { Fragment, useState } from "react";
import { useFieldArray, useForm } from "react-hook-form";

import { UnitModel } from "../../models/unit-types";

export const EnheterForm = (props: {units: UnitModel[]}) => {
  const { units } = props;
  const [correctAnswersCount, setCorrectAnswersCount] = useState(0);

  const { control, register, handleSubmit, setError, getValues, formState: { errors } } = useForm<{units: UnitModel[]}>({
    mode: 'onSubmit',
    reValidateMode: 'onSubmit',
    values: {
      units: units.map(x => { return {...x, convertTo: { value: undefined, unitType: x.convertTo.unitType }} })
    }
  });

  const { fields } = useFieldArray({
    control,
    name: "units"
  });
  

  const correctAnswers = () => {    
    getValues().units.forEach((unit: UnitModel, index: any) => {
      if (parseFloat(unit.convertTo.value?.toString() ?? '') === units[index].convertTo.value) {
        correctAnswersCount < units.length ? setCorrectAnswersCount(correctAnswersCount + 1) : setCorrectAnswersCount(correctAnswersCount);
        return;
      }
      setError(`units.${index}.convertTo.value`, { type: 'WrongAnswer', message: 'Fel svar'});
      correctAnswersCount > 0 ? setCorrectAnswersCount(correctAnswersCount - 1) : setCorrectAnswersCount(correctAnswersCount);
    });
  }

  return(
    <>
      {units.length > 0 && (
        <>
          <Box>
            <Typography variant='h5'>Antal rätt {correctAnswersCount}/{units.length}</Typography>
          </Box>
          <Box component="form" autoComplete="off" onSubmit={handleSubmit(correctAnswers)}>
            <FormGroup>
              {fields.map((item, index) => {          
                return (
                  <Fragment key={index}>
                    <FormControl sx={{ m: 1, width: '25ch' }} variant="filled" error={!!errors.units?.[index]?.convertTo?.value?.type}>
                      <Typography>{`${item.convertFrom.value} ${item.convertFrom.unitType} till`}</Typography>
                      <FilledInput
                        key={item.id}
                        {...register(`units.${index}.convertTo.value`)}
                        inputMode="numeric"                  
                        endAdornment={<InputAdornment position="end">{item.convertTo.unitType}</InputAdornment>}
                      />
                      {!!errors.units?.[index]?.convertTo?.value?.type && <FormHelperText>{errors.units?.[index]?.convertTo?.value?.message}</FormHelperText>}
                    </FormControl>
                  </Fragment>        
                );
              })}
            </FormGroup>
            <Button type='submit' variant="contained" size="medium">Rätta!</Button>
          </Box>
        </>
      )}
    </>
  )
}