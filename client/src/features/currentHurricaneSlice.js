import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane/hurricane-service';

export const loadCurrentHurricane = createAsyncThunk(
  'currentHurricane/loadCurrentHurricane',
  async (id) => {
    const data = await hurricaneServices.getHurricane(id);
    return data;
  }
);

export const currentHurricaneSlice = createSlice({
  name: 'currentHurricane',
  initialState: {
    hurricane: {},
    isLoadingCurrentHurricane: false,
    hasCurrentHurricaneError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadCurrentHurricane.pending, (state) => {
        state.isLoadingCurrentHurricane = true;
        state.hasCurrentHurricaneError = false;
      })
      .addCase(loadCurrentHurricane.fulfilled, (state, action) => {
        state.isLoadingCurrentHurricane = false;
        state.hurricane = action.payload;
      })
      .addCase(loadCurrentHurricane.rejected, (state) => {
        state.isLoadingCurrentHurricane = false;
        state.hasCurrentHurricaneError = true;
        state.hurricane = {};
      })
  },
});

export const selectCurrentHurricane = (state) => state.currentHurricane.hurricane;

export const isLoading = (state) => state.currentHurricane.isLoadingCurrentHurricane;

export const hasError = (state) => state.allHurricanes.hasCurrentHurricaneError;

export default currentHurricaneSlice.reducer;
