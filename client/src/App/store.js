import { configureStore } from '@reduxjs/toolkit';
import allHurricanesReducer from '../features/allHurricanes/allHurricanesSlice';
import currentHurricaneReducer from '../features/currentHurricane/currentHurricaneSlice';

export default configureStore({
  reducer: {
    allHurricanes: allHurricanesReducer,
    currentHurricane: currentHurricaneReducer,
  },
});
