import React, {useState, useContext} from 'react';
import {MainContext} from '../../contexts/main-context';
import {useHistory} from 'react-router-dom';
import {Avatar, Grid, Paper} from '@material-ui/core';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { authenticate } from '../../services/api-service';

function LoginComponent(props) {
    const [email, changeEmail] = useState('');
    const [password, changePassword] = useState('');
    const [isDisabled, changeDisabled] = useState(true);
    const {setJwt} = useContext(MainContext);
    const history = useHistory();

    function toggleDisabled() {
        if (email !== '' && password !== '') {
            changeDisabled(false);
        } else {
            changeDisabled(true);
        }
    }

    function handleChange(event) {
        switch (event.target.name) {
            case 'email':
                changeEmail(event.target.value);
                toggleDisabled();
                break;
            case 'password':
                changePassword(event.target.value);
                toggleDisabled();
                break;
            default:
                break;
        }
    }

    function handleSubmit(event) {
        event.preventDefault();

        authenticate({email, password})
            .then((res) => {
                return res.json();
            })
            .then((res) => {
                setJwt(res.token);
                history.push('/home');
            });
    }

    const paperStyle = {padding:20, height: '50vh', width: 280, margin: '20px auto'};
    const avatarStyle = {backgroundColor: '#40E0D0'};
    const buttonStyle = {marginTop: 40, marginBottom: 40};
    return (
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align='center'>
                    <Avatar style={avatarStyle}><LockOutlinedIcon/></Avatar>
                    <h2>Sign in</h2>
                </Grid>
                <TextField name='email' label='Email' value={email} onChange={handleChange} placeholder='Enter email' fullWidth required/>
                <TextField name='password' label='Password' 
                            placeholder='Enter password' 
                            type='password' fullWidth required value={password} onChange={handleChange}/>
                <Button style={buttonStyle} type='submit' color='primary' variant='contained' fullWidth onClick={handleSubmit} disabled={isDisabled}>Sign in</Button>
                <Typography>
                    <Link style={{textDecoration: 'none'}} to="/register">
                        Create an account
                    </Link>
                </Typography>
                <Typography align='right' style={{marginTop: 120}}>
                    <Link style={{textDecoration: 'none'}} to="/">
                        Cancel
                    </Link>
                </Typography>
            </Paper>
        </Grid>
    );
}

export default LoginComponent;