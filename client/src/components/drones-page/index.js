import React, { useState, useContext, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import { MainContext } from '../../contexts/main-context';
import { RequestsContext } from '../../contexts/requests-context';
import { getAllComments } from '../../services/api-service';
import { Grid } from '@material-ui/core';
import { getAllDrones } from '../../services/api-service';

const useStyles = makeStyles({
    root: {
        width: '30%',
        margin: '0 auto'
    },
    card: {
        minWidth: 275,
        marginTop: '1rem'
    },
    bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
    },
    title: {
        fontSize: 14,
    },
    pos: {
        marginBottom: 12,
    },
});

const DronesPage = () => {
    const [rows, setRows] = useState([]);

    const { user } = useContext(MainContext);
    const { setRequest } = useContext(RequestsContext);
    const classes = useStyles();

    useEffect(() => {
        if (user) {
            getAllDrones(user.token).then((res) => setRows(res));
        } else {
            setRows([]);
        }
    }, [user]);


    return (
        <Grid className={classes.root}>
            {rows.map((row) => {
                return (
                    <Card key={row.id} className={classes.card} variant="outlined">
                        <CardContent>
                            <Typography variant="h5" component="h2">
                                Model: {row.model}

                            </Typography>
                            <Typography variant="body2" component="p">
                                Manufacturer: {row.manufacturer}
                            </Typography>
                        </CardContent>
                    </Card>
                );
            })}
        </Grid>
    );
}

export default DronesPage;