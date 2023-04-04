import { createContext, useContext, useReducer } from "react";

import { UnitModel } from "../models/unit-types";

export const AppContext = createContext<any>(undefined!);

export const AppContextProvider = ({children}:any) => {
  const [state, dispatch] = useReducer(appReducer, initialState);  
  
  return (
    <AppContext.Provider value={{state, dispatch}}>
      {children}
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

const initialState = {
  theme: 'light',
  units: [] as UnitModel[]
}

const appReducer = (state: any, action: any) =>{
  const { theme, units } = state;

  return {
    theme: themeReducer(theme, action),
    units: unitsReducer(units, action)
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

const unitsReducer = (state: any, action: any) => {
  switch(action.type) {
    case 'ADD_UNITS': {
      return action.units;
    }
    default: return state;
  }
}