import { combineReducers, createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension'
import { userValidateReducer } from './reducers/userValidation'
import thunk from 'redux-thunk';

const reducers = combineReducers({
    userValidateReducer
});

const Store  = createStore(reducers, composeWithDevTools(applyMiddleware(thunk)));

export type RootStore = ReturnType<typeof reducers>

export default Store;