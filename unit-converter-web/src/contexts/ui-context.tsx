import { createContext, useContext, useReducer } from "react";

export const UiContext = createContext<any>(undefined!);

export const UiContextProvider = ({children}:any) => {
  const [state, dispatch] = useReducer(uiReducer, initialState);  
  
  return (
    <UiContext.Provider value={{state, dispatch}}>
      {children}
    </UiContext.Provider>
  );
}

export const useUiContext = () => {
  const context = useContext(UiContext);
  if (!context) {
    throw new Error("useUiContext must be used within a UiContextProvider");    
  }
  return context;
};

const initialState = {
  error: { openDialog: false, message: '' },
  theme: 'light'
}

const uiReducer = (state: any, action: any) =>{
  const { error, theme } = state;

  return {
    error: errorReducer(error, action),
    theme: themeReducer(theme, action)
  }
}

const errorReducer = (state: any, action: any) => {
  switch (action.type){
    case 'SHOW_ERROR': {
      return {
        openDialog: action.error.openDialog,
        message: action.error.message
      }
    }
    case 'CLEAR_ERROR': {
      return {
        openDialog: false,
        message: ''
      }
    }
    default:
      return state;
  }
};

const themeReducer = (state: any, action: any) => {
  switch(action.type){
    case 'THEME_LIGHT': {
      return 'light';
    }
    case 'THEME_DARK': {
      return 'dark';
    }
    default: return state;
  }
}