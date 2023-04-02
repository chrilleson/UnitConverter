import './styles/App.scss';

import { CssBaseline, ThemeProvider, createTheme } from '@mui/material';

import { AppContextProvider } from './contexts/app-context';
import { Header } from './components/header/header';
import { Main } from './components/main';
import { svSE } from '@mui/material/locale';
import { useMemo } from 'react';
import { useUiContext } from './contexts/ui-context';

function App() {
  const uiContext = useUiContext();
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
        <CssBaseline />
        <Header />
        <Main />
      </ThemeProvider>
    </AppContextProvider>    
  );
}

export default App;
