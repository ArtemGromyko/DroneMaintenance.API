import React from 'react';
import { Grid, Card, Typography, CardContent } from '@material-ui/core';

export default function Error({ message, code }) {

    return (
        <Grid container className='full-height' style={{width: '100%'}} justifyContent='center' alignItems='center'>
            <Card style={{width: '50%'}} >
                <CardContent>
                    <Typography variant='h5' component='h2'>
                        {message ?? 'Sorry, something went wrong'}
                    </Typography>
                </CardContent>
            </Card>
        </Grid>
    );
}