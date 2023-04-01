import { createContext, useContext, useReducer } from "react";

import { UnitModel } from "../models/unit-types";

export const AppContext = createContext<any>({});

export const AppContextProvider = ({children}:any) => {
  const [state, dispatch] = useReducer(appReducer, initialState);
  
  return <AppContext.Provider value={{state, dispatch}}>{children}</AppContext.Provider>;
}

export const useAppContext = () => useContext(AppContext);

const initialState = {
  error: { openDialog: false, message: '' },
  units: [] as UnitModel[]
}

const appReducer = (state: any, action: any) =>{
  const { error, units } = state;

  return {
    error: errorReducer(error, action),
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