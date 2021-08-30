import React, { useState, useContext } from 'react';
import { Avatar, Grid, Paper } from '@material-ui/core';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';

const useStyles = makeStyles((theme) => ({
  formControl: {
    minWidth: 120,
  },
  selectEmpty: {

  },
}));

const RequestForm = () => {
    const [serviceType, changeServiceType] = useState('');
    const [description, changeDescription] = useState('');
    const [isDisabled, changeDisabled] = useState(true);

    const classes = useStyles();

    function handleSubmit(event) {
        event.preventDefault();


    }

    function handleChange(event) {

    }

    const paperStyle = { padding: 20, height: '50vh', width: 280, margin: '20px auto' };
    const avatarStyle = { backgroundColor: '#40E0D0' };
    const buttonStyle = { marginTop: 40, marginBottom: 40 };

    return (
        <Grid>
            <Paper style={paperStyle} variant="outlined">
                <Grid align='center'>
                    <h2>Request creating</h2>
                </Grid>

                <FormControl variant="outlined" className={classes.formControl} fullWidth>
                    <InputLabel id="demo-simple-select-outlined-label">Service Type</InputLabel>
                    <Select
                        labelId="demo-simple-select-outlined-label"
                        id="demo-simple-select-outlined"
                        value={serviceType}
                        onChange={handleChange}
                        label="ServiceType"
                    >
                        <MenuItem value="">
                            <em>None</em>
                        </MenuItem>
                        <MenuItem value={10}>Ten</MenuItem>
                        <MenuItem value={20}>Twenty</MenuItem>
                        <MenuItem value={30}>Thirty</MenuItem>
                    </Select>
                </FormControl>
                <TextField name='password' label='Password'
                    placeholder='Enter password'
                    type='password' fullWidth required value={description} onChange={handleChange} variant="outlined" />
                <Button style={buttonStyle} type='submit' color='primary'
                    variant='contained' fullWidth onClick={handleSubmit} disabled={isDisabled}>
                    Create
                </Button>

                <Typography align='right' style={{ marginTop: 100 }}>
                    <Link style={{ textDecoration: 'none' }} to="/">
                        Cancel
                    </Link>
                </Typography>
            </Paper>
        </Grid>
    );
}

export default RequestForm;