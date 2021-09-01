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
import { RequestsContextProvider } from '../../contexts/requests-context';
import CommentsPage from '../comments-page';

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
            <RequestsContextProvider>
                <Route path='/requests'>
                    <WithJwt>
                        <Header />
                        <RequestsPage />
                    </WithJwt>
                </Route>
                <Route path='/request-creating'>
                    <WithJwt>
                        <RequestForm mode='creating' />
                    </WithJwt>
                </Route>
                <Route path='/request-editing'>
                    <WithJwt>
                        <RequestForm mode='editing' />
                    </WithJwt>
                </Route>
                <Route path='/request-editing'>
                    <WithJwt>
                        <RequestForm mode='editing' />
                    </WithJwt>
                </Route>
                <Route path='/comments'>
                    <WithJwt>
                        <Header />
                        <CommentsPage />
                    </WithJwt>
                </Route>
            </RequestsContextProvider>
        </div>
    );
}

export default App;