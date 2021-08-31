import React from 'react';
import { Route } from 'react-router-dom';
import LoggedComponent from '../logged-component';
import WithJwt from '../with-jwt';
import Header from '../header';
import AuthComponent from '../auth-component';
import MainPage from '../main-page';
import './app.css';
import RequestsPage from '../requests-page';
import RequestForm from '../request-form';

function App() {
    return (
        <div>
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
                <WithJwt>
                    <Header />
                    <LoggedComponent />
                </WithJwt>
            </Route>
            <Route path='/requests'>
                <WithJwt>
                    <Header />
                    <RequestsPage />
                </WithJwt>
            </Route>
            <Route path='/request-creating'>
                <WithJwt>
                    <RequestForm mode='creating'/>
                </WithJwt>
            </Route>
            <Route path='/request-editing'>
                <WithJwt>
                    <RequestForm mode='editing'/>
                </WithJwt>
            </Route>
        </div>
    );
}

export default App;