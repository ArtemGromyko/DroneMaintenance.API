import React from 'react';
import CircularProgress from '@mui/material/CircularProgress';
import { Grid } from '@material-ui/core';

export default function Spinner() {
    return (
        <Grid item container alignItems='center' justifyContent='center'>
            <CircularProgress size={100} />
        </Grid>
    );
}