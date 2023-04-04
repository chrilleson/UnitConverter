import { Box, Container, Grid, Paper, Toolbar } from "@mui/material";

import { Enheter } from "./enheter/enheter";
import { ErrorSnackbar } from "./snackbar/error";
import { useUiContext } from "../contexts/ui-context";

export const Main = () => {
  const uiContext = useUiContext();
  return(
    <Box component='main' sx={{flexGrow: 1, overflow: 'auto'}}>
      <Paper sx={{ p: 2, display: 'flex', flexDirection: 'column'}}>
        <Toolbar />
        <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
          <Grid container spacing={2}>
            <Grid item xs={2}>
              <Enheter />
            </Grid>
            <Grid item xs={10}>
                 
            </Grid>
          </Grid>
        </Container>
      </Paper>
      {!!uiContext.state.error && <ErrorSnackbar openDialog={uiContext.state.error.openDialog} message={uiContext.state.error.message} />}
    </Box>    
  );
}