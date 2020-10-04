import React, { Component } from 'react';
import { connect } from 'react-redux'
import Page from './page';

interface ILogin {
    login?: any
}

class Login extends Component<ILogin> {
    render() {
        const { login } = this.props;

        return (
            <Page login={login}/>
        );  
    };
}

const mapStateToProps = (state: any) => {
    return {
        login: state.userValidation,
    }
};

export default connect(mapStateToProps)(Login);