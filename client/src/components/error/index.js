import React from 'react';
import { Grid, Card, Typography, CardContent } from '@material-ui/core';

export default function Error({ message, code }) {

    return (
        <Grid style={{width: '50%', margin: '0 auto', marginTop: '2rem'}} justifyContent='center' alignItems='center'>
            <Card>
                <CardContent>
                    <Typography variant='h5' component='h2'>
                        {message ?? 'Sorry, something went wrong'}
                    </Typography>
                </CardContent>
            </Card>
        </Grid>
    );
}