//Imports createAsyncThunk and createSlice from Redux's toolkit, and hurricaneServices from hurricane-service for API calls
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import * as hurricaneServices from '../utilities/hurricane/hurricane-service';

//Exports loadCurrentHurricane async thunk that calls hurricaneServices.getHurricane() with the argument id and returns the result
export const loadCurrentHurricane = createAsyncThunk(
  'currentHurricane/loadCurrentHurricane',
  async (id) => {
    const data = await hurricaneServices.getHurricane(id);
    return data;
  }
);

//Exports the currentHurricaneSlice Redux slice named currentHurricane with hurricane state (initiated as an empty object), and loadCurrentHurricane as an extra reducer
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

//Exports currentHurricane state, the hurricanes object
export const selectCurrentHurricane = (state) => state.currentHurricane.hurricane;

//Exports currentHurricane state, the isLoadingCurrentHurricane boolean, as isLoading
export const isLoading = (state) => state.currentHurricane.isLoadingCurrentHurricane;

//Exports currentHurricane state, the hasCurrentHurricaneError boolean, as hasError
export const hasError = (state) => state.allHurricanes.hasCurrentHurricaneError;

//Default exports currentHurricaneSlice reducer
export default currentHurricaneSlice.reducer;
