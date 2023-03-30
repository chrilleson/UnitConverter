import './styles/App.scss';

import { CssBaseline, ThemeProvider, createTheme } from '@mui/material';

import { Header } from './components/header/header';
import { Main } from './components/main';
import { svSE } from '@mui/material/locale';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },  
}, svSE);

function App() {
  return (
    <ThemeProvider theme={darkTheme}>
      <CssBaseline />
      <Header />
      <Main />
    </ThemeProvider>
  );
}

export default App;
