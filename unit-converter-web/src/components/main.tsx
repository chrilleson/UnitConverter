import { Box, Container, Grid, Paper, Toolbar } from "@mui/material";
import { useEffect, useState } from "react";

import { Enheter } from "./enheter/enheter";
import { EnheterForm } from "./enheter/enheter-form";
import { ErrorSnackbar } from "./snackbar/error";
import { UnitModel } from "../models/unit-types";
import { useAppContext } from "../contexts/app-context";
import { useUiContext } from "../contexts/ui-context";

export const Main = () => {
  const uiContext = useUiContext();
  const appContext = useAppContext();
  const [units, setUnits] = useState<UnitModel[]>([]);

  useEffect(() => {
    setUnits(appContext.state.units)
  }, [appContext.state, appContext.state.units]);

  return(
    <Box component='main' sx={{flexGrow: 1, overflow: 'auto'}}>
      <Paper sx={{ p: 2, display: 'flex', flexDirection: 'column'}}>
        <Toolbar />
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
          <Grid container spacing={2}>
            <Grid item>
              <Enheter />
            </Grid>
            <Grid item>
             <EnheterForm units={units} />
            </Grid>
          </Grid>
        </Container>
      </Paper>
      {!!uiContext.state.error && <ErrorSnackbar openDialog={uiContext.state.error.openDialog} message={uiContext.state.error.message} />}
    </Box>    
  );
}