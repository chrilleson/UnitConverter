import './styles/index.scss';

import App from './App';
import { StrictMode } from 'react';
import { UiContextProvider } from './contexts/ui-context';
import { createRoot } from 'react-dom/client';
import reportWebVitals from './reportWebVitals';

const container = document.getElementById('root');
const root = createRoot(container!);


root.render(
  <StrictMode>
    <UiContextProvider>
      <App />
    </UiContextProvider>
  </StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
