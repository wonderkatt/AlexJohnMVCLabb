import React from 'react'
import { Redirect, Route } from 'react-router-dom'

let isAuthenticated = false;

const PrivateRoute = ({ component: Component, ...rest }) => {

    checkAuthenticated();

    return (
        <Route
            {...rest}
            render={props =>
                isAuthenticated === true ? (
                    <Component {...props} />
                ) : (
                        <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
                    )
            }
        />
    )
}

async function checkAuthenticated() {

    await fetch('/account/authorize')
        .then((response) => response.json())
        .then((jsonResponse) =>
        {
            isAuthenticated = jsonResponse.success;
        });

}
export default PrivateRoute