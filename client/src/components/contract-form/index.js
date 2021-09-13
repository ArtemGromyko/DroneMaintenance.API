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
import { createRequestForUser, updateRequestForUser } from '../../services/api-service';
import { MainContext } from '../../contexts/main-context';
import { useHistory } from 'react-router';
import { RequestsContext } from '../../contexts/requests-context';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { getParts } from '../../services/api-service/partsService';

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
    },
    textField: {
        marginTop: '2rem'
    }
}));

const ContractForm = () => {
    const [rows, setRows] = useState([]);
    const { user } = useContext(MainContext);
    const classes = useStyles();

    useEffect(() => {
        if (user) {
            getParts(user.token).then((res) => {
                setRows(res);
            })
            console.log(rows);
        } else {
            setRows([]);
        }
    }, [user]);

    return (
        <Typography>
            <Grid>
                <Paper className={classes.paperStyle} variant="outlined">
                    <Grid align='center'>
                        <h2>Hello</h2>
                    </Grid>
                    <Autocomplete
                        id="combo-box-demo"
                        options={rows}
                        getOptionLabel={(option) => option.name}
                        renderInput={(params) => <TextField {...params} label="Combo box" variant="outlined" />}
                    />
                    <TextField name='description' label='Description'
                        className={classes.textField}
                        type='number'
                        placeholder='Enter description'
                        min={0}
                        fullWidth variant="outlined" />
                    <Grid direction='row' container alignItems='center' justifyContent='space-between'>
                    <Button className={classes.buttonStyle} type='submit' color='primary'
                        variant='contained'>
                            Add
                    </Button>
                    <Button className={classes.buttonStyle} type='submit' color='primary'
                        variant='contained'>
                            Submit
                    </Button>
                    </Grid>
                
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

export default ContractForm;