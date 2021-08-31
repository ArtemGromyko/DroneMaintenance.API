import React, { useState, useEffect, useContext } from 'react';
import { Grid, Paper } from '@material-ui/core';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { createRequestForUser } from '../../services/api-service';
import { MainContext } from '../../contexts/main-context';
import { useHistory } from 'react-router';

const useStyles = makeStyles(() => ({
    root: {
        minWidth: 120,
        marginBottom: '2rem',
        marginTop: '5rem'
    },
    paperStyle: {
        padding: 20,
        height: '50vh',
        width: 280,
        margin: '20px auto'
    },
    buttonStyle: {
        marginTop: '2rem',
        marginBottom: '2rem'
    }
}));

const RequestForm = ({ mode }) => {
    const [serviceType, changeServiceType] = useState('');
    const [description, changeDescription] = useState('');
    const [isDisabled, changeDisabled] = useState(true);

    const { user } = useContext(MainContext);
    const  history = useHistory();

    useEffect(() => {
        if (serviceType === '') {
            changeDisabled(true);
        } else {
            changeDisabled(false);
        }
    }, [serviceType]);

    useEffect(() => {
        if (mode === 'editing') {

        }
    }, []);

    const classes = useStyles();

    async function handleSubmit(event) {
        event.preventDefault();

        let res;
        if(mode === 'creating') {
            res = await handleCreate();
        }
        else {
            res = await handleUpdate();
        }

        if(res.ok) {
            history.push('/requests');
        }
    }

    function handleChange(event) {
        switch (event.target.name) {
            case 'description':
                changeDescription(event.target.value);
                break;
            case 'serviceType':
                changeServiceType(event.target.value);
                console.log(event.target.value);
                console.log(serviceType);
                break;
        }
    }

    async function handleCreate() {
        const request = {
            serviceType,
            description
        };

        return await createRequestForUser(user.id, user.token, request)
    }

    async function handleUpdate() {

    }

    return (
        <Typography>
            <Grid>
                <Paper className={classes.paperStyle} variant="outlined">
                    <Grid align='center'>
                        <h2>{mode === 'creating' ? 'Request creating' : 'Request editing'}</h2>
                    </Grid>
                    <FormControl variant="outlined" className={classes.root} fullWidth>
                        <InputLabel id="serviceType" required>Service Type</InputLabel>
                        <Select
                            labelId="serviceType"
                            value={serviceType}
                            onChange={handleChange}
                            name="serviceType"
                            label="Service Type"
                        >
                            <MenuItem value=''>None</MenuItem>
                            <MenuItem value={0}>Repair without replacement</MenuItem>
                            <MenuItem value={1}>Repair with replacement </MenuItem>
                            <MenuItem value={2}>Diagnostics</MenuItem>
                        </Select>
                    </FormControl>
                    <TextField name='description' label='Description'
                        placeholder='Enter description'
                        fullWidth value={description} onChange={handleChange} variant="outlined" multiline rows={4} />
                    <Button className={classes.buttonStyle} type='submit' color='primary'
                        variant='contained' fullWidth onClick={handleSubmit} disabled={isDisabled}>
                        {mode === 'creating' ? 'Create' : 'Update'}
                    </Button>

                    <Typography align='right' style={{ marginTop: '1.5rem' }}>
                        <Link style={{ textDecoration: 'none' }} to="/requests">
                            Cancel
                        </Link>
                    </Typography>
                </Paper>
            </Grid>
        </Typography>
    );
}

export default RequestForm;