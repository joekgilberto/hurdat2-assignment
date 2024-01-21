import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane-service';

export const loadAllHuricanes = createAsyncThunk(
  'allHurricanes/loadAllHuricanes',
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
    hasAllHurricaneError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadAllHuricanes.pending, (state) => {
        state.isLoadingAllHurricanes = true;
        state.hasAllHurricaneError = false;
      })
      .addCase(loadAllHuricanes.fulfilled, (state, action) => {
        state.isLoadingAllHurricanes = false;
        state.allHurricanes = action.payload;
        console.log(state.allHurricanes)
      })
      .addCase(loadAllHuricanes.rejected, (state, action) => {
        state.isLoadingAllHurricanes = false;
        state.hasAllHurricaneError = true;
        state.allHurricanes = [];
      })
  },
});

export const selectAllHurricanes = (state) => state.allHurricanes.allHurricanes;

export const isLoading = (state) => state.allHurricanes.isLoadingAllHurricanes;

export const hasError = (state) => state.allHurricanes.hasAllHurricaneError;

export default allHurricanesSlice.reducer;
