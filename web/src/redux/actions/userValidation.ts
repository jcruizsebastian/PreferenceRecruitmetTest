import { LOGIN_LOADING, LOGIN_FAIL, LOGIN_SUCCESS } from '../constants'
import { Dispatch } from 'redux'
import { UserValidationTypes } from '../types/userValidation'
import { login } from '../../services/user'

export const Dologin = (userName: string, password: string) => async (dispatch: Dispatch<UserValidationTypes>) => {
    try{
        dispatch({ 
            type: LOGIN_LOADING
        });

        const res = await login(userName, password);
        
        dispatch({ 
            type: LOGIN_SUCCESS,
            payload: res.data.login
         });
    }catch(e)
    {
        dispatch({ 
            type: LOGIN_FAIL
        });
    }
}

// export function logout (): LogoutAction {
//     return {
//         type: LOGIN_LOGOUT
//     };
// }