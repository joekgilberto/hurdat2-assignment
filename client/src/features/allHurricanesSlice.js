import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

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
    hasError: false
  },
  extraReducers: (builder) => {
    builder
      .addCase(loadAllHuricanes.pending, (state) => {
        state.isLoadingAllHurricanes = true;
        state.hasError = false;
      })
      .addCase(loadAllHuricanes.fulfilled, (state, action) => {
        state.isLoadingAllHurricanes = false;
        state.allHurricanes = action.payload;
      })
      .addCase(loadAllHuricanes.rejected, (state) => {
        state.isLoadingAllHurricanes = false;
        state.hasError = true;
        state.allHurricanes = [];
      })
  },
});

export const selectAllHurricanes = (state) => state.allHurricanes.allHurricanes;

export const isLoading = (state) => state.allHurricanes.isLoading;

export default allHurricanesSlice.reducer;
