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
  theme: 'light'
}

const uiReducer = (state: any, action: any) =>{
  const { theme} = state;

  return {
    theme: themeReducer(theme, action)
  }
}


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