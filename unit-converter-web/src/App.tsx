import './styles/App.scss';

import { Box, CssBaseline, ThemeProvider, createTheme } from '@mui/material';

import { AppContextProvider } from './contexts/app-context';
import { Header } from './components/header/header';
import { Main } from './components/main';
import axios from 'axios';
import { setupAxios } from './services/http.service';
import { svSE } from '@mui/material/locale';
import { useMemo } from 'react';
import { useUiContext } from './contexts/ui-context';

function App() {
  const uiContext = useUiContext();
  setupAxios(axios, uiContext)
  const theme = useMemo(
    () =>
      createTheme({
        palette: {
          mode: uiContext.state.theme,
        },
      }, svSE),
    [uiContext.state.theme],
  );

  return (
    <AppContextProvider>
      <ThemeProvider theme={theme}>
        <Box sx={{ display: 'flex' }}>
          <CssBaseline />
          <Header />
          <Main />
        </Box>
      </ThemeProvider>
    </AppContextProvider>    
  );
}

export default App;
