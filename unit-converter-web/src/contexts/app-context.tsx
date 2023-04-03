import { createContext, useContext, useReducer } from "react";

import { UnitModel } from "../models/unit-types";

export const AppContext = createContext<any>(undefined!);
export const AppContextDispatch = createContext<any>(undefined!);

export const AppContextProvider = ({children}:any) => {
  const [state, dispatch] = useReducer(appReducer, initialState);  
  
  return (
    <AppContext.Provider value={state}>
      <AppContextDispatch.Provider value={dispatch}>{children}</AppContextDispatch.Provider>
    </AppContext.Provider>
  );
}

export const useAppContext = () => {
  const context = useContext(AppContext);
  if (!context) {
    throw new Error("useAppContext must be used within a AppContextProvider");    
  }
  return context;
};
export const useAppContextDispatch = () => useContext(AppContextDispatch);

const initialState = {
  error: { openDialog: false, message: '' },
  theme: 'light',
  units: [] as UnitModel[]
}

const appReducer = (state: any, action: any) =>{
  const { error, theme, units } = state;

  return {
    error: errorReducer(error, action),
    theme: themeReducer(theme, action),
    units: unitsReducer(units, action)
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

const unitsReducer = (state: any, action: any) => {
  switch(action.type) {
    case 'ADD_UNITS': {
      return {
        units: action.units
      }
    }
    default: return state;
  }
}