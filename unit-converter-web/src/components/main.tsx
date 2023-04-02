import { Box, Container, Grid, Paper, Toolbar } from "@mui/material";

import { Enheter } from "./enheter/enheter";

export const Main = () => {
  return(
    <Box component='main'>
      <Paper>
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
    </Box>    
  );
}