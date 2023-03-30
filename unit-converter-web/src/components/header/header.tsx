import { AppBar, Toolbar, Typography } from '@mui/material';

export const Header = () => {
  return(
    <AppBar position="absolute">
      <Toolbar>
        <Typography
          component="h1"
          variant="h6"
          color="inherit"
          noWrap
        >
          Enhetsomvandlaren
        </Typography>
      </Toolbar>
  </AppBar>
  )
}