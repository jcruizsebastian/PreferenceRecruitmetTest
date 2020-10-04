import { LOGIN_FAIL, LOGIN_SUCCESS, LOGIN_LOADING } from '../constants'

export interface Error {
    message: string
}

export interface UserValidationState {
    userName: string,
    id: number,
    loading: boolean,
    error: Error
}

export interface LoginLoadingAction {
    type: typeof LOGIN_LOADING
}

export interface LoginFailAction {
    type: typeof LOGIN_FAIL
}

export interface LoginSuccessAction {
    type: typeof LOGIN_SUCCESS,
    payload: UserValidationState
}

// export interface LogoutAction {
//     type: typeof LOGIN_LOGOUT
// }

export type UserValidationTypes = LoginLoadingAction | LoginFailAction | LoginSuccessAction;
