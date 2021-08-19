import React from 'react';
import { Switch, Route } from 'react-router-dom';
import LoggedComponent from '../logged-component';
import WithJwt from '../with-jwt';
import Header from '../header';
import AuthComponent from '../auth-component';
import MainPage from '../main-page';

import './app.css';

function App() {
    return (
        <>
            <Route exact path='/'>
                <Header />
                <MainPage />
            </Route>
            <Route path='/login'>
                <AuthComponent />
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
        </>
    );
}

export default App;