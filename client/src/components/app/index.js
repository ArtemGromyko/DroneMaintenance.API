import React from 'react';
import { Switch, Route } from 'react-router-dom';

import LoginComponent from '../login-component';
import LoggedComponent from '../logged-component';
import WithJwt from '../with-jwt';
import Header from '../header';
import AuthComponent from '../auth-component';

import './app.css';

function App() {
    return (
        <Switch>
            <Route exact path='/'>
                <Header />
                <div>hello world</div>
            </Route>
            <Route path='/login'>
                <AuthComponent/>
            </Route>
            <Route path='/register'>
                <AuthComponent isSignUp />
            </Route>
            <Route path='/home'>
                <Header />
                <WithJwt>
                    <LoggedComponent />
                </WithJwt>
            </Route>
        </Switch>
    );
}

export default App;