import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane-service';

export const loadCurrentHuricane = createAsyncThunk(
  'currentHurricane/loadCurrentHuricane',
  async (id) => {
    const data = await hurricaneServices.getHurricane(id);
    return data;
  }
);

export const currentHurricaneSlice = createSlice({
  name: 'currentHurricane',
  initialState: {
    hurricane: {},
    isLoadingCurrentHuricane: false,
    hasCurrentHurricaneError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadCurrentHuricane.pending, (state) => {
        state.isLoadingCurrentHuricane = true;
        state.hasCurrentHurricaneError = false;
      })
      .addCase(loadCurrentHuricane.fulfilled, (state, action) => {
        state.isLoadingCurrentHuricane = false;
        state.hurricane = action.payload;
      })
      .addCase(loadCurrentHuricane.rejected, (state) => {
        state.isLoadingCurrentHuricane = false;
        state.hasCurrentHurricaneError = true;
        state.hurricane = {};
      })
  },
});

export const selectCurrentHurricane = (state) => state.currentHurricane.hurricane;

export const isLoading = (state) => state.currentHurricane.isLoadingCurrentHuricane;

export const hasError = (state) => state.allHurricanes.hasCurrentHurricaneError;

export default currentHurricaneSlice.reducer;
