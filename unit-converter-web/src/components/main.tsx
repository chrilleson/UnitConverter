import { Box, Container, Grid, Toolbar } from "@mui/material";

import { Enheter } from "./enheter/enheter";

export const Main = () => {
  return(
    <Box component='main'>
      <Toolbar />
      <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
        <Grid container spacing={2}>
          <Grid item xs>
            <Enheter />
          </Grid>
        </Grid>
      </Container>
    </Box>    
  );
}