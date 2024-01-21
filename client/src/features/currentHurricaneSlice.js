import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

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
    hasError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadCurrentHuricane.pending, (state) => {
        state.isLoadingCurrentHuricane = true;
        state.hasError = false;
      })
      .addCase(loadCurrentHuricane.fulfilled, (state, action) => {
        state.isLoadingCurrentHuricane = false;
        state.hurricane = action.payload;
      })
      .addCase(loadCurrentHuricane.rejected, (state) => {
        state.isLoadingCurrentHuricane = false;
        state.hasError = true;
        state.hurricane = {};
      })
  },
});

export const selectCurrentHurricane = (state) => state.currentHurricane.hurricane;

export const isLoading = (state) => state.currentHurricane.isLoading;

export default currentHurricaneSlice.reducer;
