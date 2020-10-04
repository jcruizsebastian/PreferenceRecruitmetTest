import React, { Fragment } from 'react';
import { RootStore } from '../../redux/index'
import { useDispatch, useSelector } from "react-redux";
import { Dologin } from '../../redux/actions/userValidation'
import { UserValidationState } from '../../redux/types/userValidation'
import { Redirect } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';

var password: string;
var userName: string;

function Page(props: any) {
    const dispatch = useDispatch();
    const userState: UserValidationState = useSelector((state: RootStore) => state.userValidateReducer);

    function handleChangeUserName(e: React.ChangeEvent<HTMLInputElement>) {
        userName = e.target.value;
    };

    function handleChangePassword(e: React.ChangeEvent<HTMLInputElement>) {
        password = e.target.value;
    };

    function submit() {
        dispatch(Dologin(userName, password));
    }

    console.log("pokemon state:", userState);

    if (!userState.loading && userState.id != null)
        return (<Redirect to='/App' />)
    else {
        return (

                <Form>
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email address</Form.Label>
                        <Form.Control type="string" id="tbUserName" onChange={handleChangeUserName} placeholder="Enter your username" />
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" id="tbPassword" onChange={handleChangePassword} placeholder="Enter your password" />
                    </Form.Group>
                    <Button variant="primary" onClick={submit} id="btnLogin">
                    Login
                    </Button>
                </Form>
        );
    }
}

export default Page;