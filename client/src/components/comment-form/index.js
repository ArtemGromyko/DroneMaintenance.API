import React, { useState, useEffect, useContext } from 'react';
import { Grid, Paper } from '@material-ui/core';
import { TextField } from '@material-ui/core';
import { Button } from '@material-ui/core';
import { Typography } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { makeStyles } from '@material-ui/core/styles';
import { MainContext } from '../../contexts/main-context';
import { RequestsContext } from '../../contexts/requests-context';
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

export default function CommentForm() {
    

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
                            {
                                serviceTypes.map((st) => {
                                    return (
                                        <MenuItem value={st.value}>{st.label}</MenuItem>
                                    )
                                })
                            }
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