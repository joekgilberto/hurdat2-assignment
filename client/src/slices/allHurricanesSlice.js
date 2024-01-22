//Imports createAsyncThunk and createSlice from Redux's toolkit, and hurricaneServices from hurricane-service for API calls
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane/hurricane-service';

//Exports loadAllHurricanes async thunk that calls hurricaneServices.getAllHurricanes() and returns the result
export const loadAllHurricanes = createAsyncThunk(
  'allHurricanes/loadAllHurricanes',
  async () => {
    const data = await hurricaneServices.getAllHurricanes();
    return data;
  }
);

//Exports the allHurricanesSlice Redux slice named allHurricanes with hurricanes state (initiated as an empty array), and loadAllHurricanes as an extra reducer
export const allHurricanesSlice = createSlice({
  name: 'allHurricanes',
  initialState: {
    hurricanes: [],
    isLoadingAllHurricanes: false,
    hasAllHurricanesError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadAllHurricanes.pending, (state) => {
        state.isLoadingAllHurricanes = true;
        state.hasAllHurricanesError = false;
      })
      .addCase(loadAllHurricanes.fulfilled, (state, action) => {
        state.isLoadingAllHurricanes = false;
        state.hurricanes = action.payload;
      })
      .addCase(loadAllHurricanes.rejected, (state) => {
        state.isLoadingAllHurricanes = false;
        state.hasAllHurricanesError = true;
        state.hurricanes = [];
      })
  },
});

//Exports allHuricanes state, the hurricanes array
export const selectAllHurricanes = (state) => state.allHurricanes.hurricanes;

//Exports allHuricanes state, the isLoadingAllHurricanes boolean, as isLoading
export const isLoading = (state) => state.allHurricanes.isLoadingAllHurricanes;

//Exports allHuricanes state, the hasAllHurricanesError boolean, as hasError
export const hasError = (state) => state.allHurricanes.hasAllHurricanesError;

//Default exports allHurricanesSlice reducer
export default allHurricanesSlice.reducer;
