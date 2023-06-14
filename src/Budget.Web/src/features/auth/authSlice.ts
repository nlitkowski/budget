import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../app/store';
import { ILoginPayload } from './interfaces/ILoginPayload';
import { ApiClient } from '../../api/client';
import { IToken } from './interfaces/IToken';

export interface AuthState {
    authorized: boolean;
    token: IToken | null;
}

const initialState: AuthState = {
    authorized: false,
    token: null
};

export const loginAsync = createAsyncThunk(
    'auth/login',
    async (payload: ILoginPayload): Promise<IToken> => {
        const response = await ApiClient.post("auth/login", payload);
        console.log(response);
        return response.data as IToken;
    }
);

export const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        authorize: (state, payload) => {
            state.authorized = true;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginAsync.fulfilled, (state, action) => {
                state.authorized = true;
                state.token = action.payload;
            })
            .addCase(loginAsync.rejected, (state) => {
                state.authorized = false;
            });
    },
});

export const { authorize } = authSlice.actions;

export const selectIsAuthorized = (state: RootState) => state.auth.authorized;

export default authSlice.reducer;