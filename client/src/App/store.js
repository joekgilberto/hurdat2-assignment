//Imports configureStore from the Redux toolkiit along with reducers
import { configureStore } from '@reduxjs/toolkit';
import allHurricanesReducer from '../slices/allHurricanesSlice';
import currentHurricaneReducer from '../slices/currentHurricaneSlice';

//Exports a configureStore method with allHurricanesReducer and currentHurricaneReducer passed as reducers
export default configureStore({
  reducer: {
    allHurricanes: allHurricanesReducer,
    currentHurricane: currentHurricaneReducer,
  },
});
