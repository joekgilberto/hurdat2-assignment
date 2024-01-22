//Imports configureStore from the Redux toolkit along with reducers
import { configureStore } from '@reduxjs/toolkit';
import allHurricanesReducer from '../slices/allHurricanesSlice';
import currentHurricaneReducer from '../slices/currentHurricaneSlice';

//Exports the result of the configureStore method with allHurricanesReducer and currentHurricaneReducer passed as reducers
export default configureStore({
  reducer: {
    allHurricanes: allHurricanesReducer,
    currentHurricane: currentHurricaneReducer,
  },
});
