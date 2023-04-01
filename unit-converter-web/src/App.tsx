import './styles/App.scss';

import { CssBaseline, ThemeProvider, createTheme, useMediaQuery } from '@mui/material';

import { Header } from './components/header/header';
import { Main } from './components/main';
import { svSE } from '@mui/material/locale';
import { useMemo } from 'react';

function App() {

  const prefersDarkMode = useMediaQuery('(prefers-color-scheme: dark)');

  const theme = useMemo(
    () =>
      createTheme({
        palette: {
          mode: prefersDarkMode ? 'dark' : 'light',
        },
      }, svSE),
    [prefersDarkMode],
  );

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header />
      <Main />      
    </ThemeProvider>
  );
}

export default App;
