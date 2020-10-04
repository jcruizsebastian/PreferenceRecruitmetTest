import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter, Route, Redirect, Switch } from 'react-router-dom';
import store from './redux';
import './index.css';
import Login from './components/login'
import 'bootstrap/dist/css/bootstrap.min.css';

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <Switch>
        <Route path='/login' component={Login} />
        <Redirect from='/' to='/login' />
      </Switch>
    </BrowserRouter>
  </Provider>
  ,
  document.getElementById('root')
);