import React, {useState, useContext} from 'react';
import {MainContext} from '../../contexts/main-context';
import {useHistory} from 'react-router-dom';
import {ApiContext} from '../../contexts/api-context';
import {Avatar, Grid, Paper} from '@material-ui/core';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';

function RegisterComponent(props) {
    const [name, changeName] = useState('');
    const [email, changeEmail] = useState('');
    const [password, changePassword] = useState('');
    const [isDisabled, changeDisabled] = useState(true);
    const {setJwt} = useContext(MainContext);
    const apiService = useContext(ApiContext);
    const history = useHistory();

    function toggleDisabled() {
        if (email !== '' && password !== '' && name !=='') {
            changeDisabled(false);
        } else {
            changeDisabled(true);
        }
    }

    function handleChange(event) {
        switch (event.target.name) {
            case 'name':
                changeName(event.target.value);
                toggleDisabled();
                break;
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

        apiService.register({email, name, password})
            .then((res) => {
                return res.json();
            })
            .then((res) => {
                setJwt(res.token);
                history.push('/home');
            });
    }

    const paperStyle = {padding:20, height: '50vh', width: 280, margin: '20px auto'};
    const avatarStyle = {backgroundColor: '#40E0D0'}
    const buttonStyle = {marginTop: 40, marginBottom: 40}
    return (
        <Grid>
            <Paper elevation={10} style={paperStyle}>
                <Grid align='center'>
                    <Avatar style={avatarStyle}><AccountCircleIcon/></Avatar>
                    <h2>Sign up</h2>
                </Grid>
                <TextField name='name' label='Name' value={name} onChange={handleChange} placeholder='Enter name' fullWidth required/>
                <TextField name='email' label='Email' value={email} onChange={handleChange} placeholder='Enter email' fullWidth required/>
                <TextField name='password' label='Password' 
                            placeholder='Enter password' 
                            type='password' fullWidth required value={password} onChange={handleChange}/>
                <Button style={buttonStyle} type='submit' color='primary' 
                        variant='contained' fullWidth onClick={handleSubmit} disabled={isDisabled}>Sign up</Button>
                <Typography align='right' style={{marginTop: 100}}>
                    <Link style={{textDecoration: 'none'}} to="/">
                        Cancel
                    </Link>
                </Typography>
            </Paper>
        </Grid>
    );
}

export default RegisterComponent;