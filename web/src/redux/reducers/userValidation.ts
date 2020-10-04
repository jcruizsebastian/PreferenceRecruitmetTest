import { LOGIN_LOADING, LOGIN_FAIL,  LOGIN_SUCCESS } from '../constants'
import { UserValidationState, UserValidationTypes } from '../types/userValidation'

export function userValidateReducer(state: UserValidationState, action: UserValidationTypes) {
    switch (action.type) {
        case LOGIN_LOADING:
            return {
                loading: true,
            };
        case LOGIN_SUCCESS:
            return {
                loading: false,
                userName: action.payload.userName,
                id: action.payload.id,
            };
        case LOGIN_FAIL:
            return {
                loading: false,
                error: { message: 'Failed connecting' }
            };
        default: return {};
    }
}

// export function userLogoutReducer(state: UserValidationState, action: LogoutAction) {
//     switch (action.type) {
//         case LOGIN_LOGOUT:
//             return { };
//         default: return {};
//     }
// }