import React, { useState, useEffect, useContext } from 'react';
import { Grid, Paper } from '@material-ui/core';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { MainContext } from '../../contexts/main-context';
import { modelContext } from '../../contexts/models-context';
import Autocomplete from '@material-ui/lab/Autocomplete';
import { getParts } from '../../services/api-service/parts-service';

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
        marginTop: '5rem',
        marginBottom: '2rem'
    },
    textField: {
        marginTop: '2rem'
    }
}));

const ContractForm = () => {
    const [rows, setRows] = useState([]);
    const classes = useStyles();

    const { user } = useContext(MainContext);
    const { model } = useContext(modelContext);

    useEffect(() => {
        if (user) {
            getParts(user.token).then((res) => {
                setRows(res);
            })
            console.log(rows);
        } else {
            setRows([]);
        }
        console.log(model);
    }, [user]);

    return (
        <Typography>
            <Grid>
                <Paper className={classes.paperStyle} variant="outlined">
                    <Grid align='center'>
                        <h2>Add spare parts</h2>
                    </Grid>
                    <Autocomplete
                        id="spare-part"
                        options={rows}
                        getOptionLabel={(option) => option.name}
                        renderInput={(params) => <TextField {...params} label="Spare part" variant="outlined" />}
                    />
                    <TextField name='quantity' label='Quantity'
                        className={classes.textField}
                        type='number'
                        placeholder='Enter quantity'
                        min={0}
                        fullWidth variant="outlined" />
                    <Button className={classes.buttonStyle} type='submit' color='primary'
                        variant='contained' fullWidth>
                            Add
                    </Button>
                    <Typography align='right' style={{ marginTop: '6rem' }}>
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