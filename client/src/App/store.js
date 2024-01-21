import { configureStore } from '@reduxjs/toolkit';
import allHurricanesReducer from '../features/allHurricanesSlice';
import currentHurricaneReducer from '../features/currentHurricaneSlice';

export default configureStore({
  reducer: {
    allHurricanes: allHurricanesReducer,
    currentHurricane: currentHurricaneReducer,
  },
});
