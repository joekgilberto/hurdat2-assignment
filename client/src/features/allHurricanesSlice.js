import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane/hurricane-service';

export const loadAllHurricanes = createAsyncThunk(
  'allHurricanes/loadAllHurricanes',
  async () => {
    const data = await hurricaneServices.getAllHurricanes();
    return data;
  }
);

export const allHurricanesSlice = createSlice({
  name: 'allHurricanes',
  initialState: {
    allHurricanes: [],
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
        state.allHurricanes = action.payload;
        console.log(state.allHurricanes)
      })
      .addCase(loadAllHurricanes.rejected, (state, action) => {
        state.isLoadingAllHurricanes = false;
        state.hasAllHurricanesError = true;
        state.allHurricanes = [];
      })
  },
});

export const selectAllHurricanes = (state) => state.allHurricanes.allHurricanes;

export const isLoading = (state) => state.allHurricanes.isLoadingAllHurricanes;

export const hasError = (state) => state.allHurricanes.hasAllHurricanesError;

export default allHurricanesSlice.reducer;
