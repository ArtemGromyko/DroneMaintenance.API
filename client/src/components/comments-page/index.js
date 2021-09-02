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
import { useHistory } from 'react-router';
import { Grid } from '@material-ui/core';

const useStyles = makeStyles({
    root: {
        width: '60%',
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

const CommentsPage = () => {
    const [rows, setRows] = useState([]);

    const { user } = useContext(MainContext);
    const history = useHistory();
    const { setRequest } = useContext(RequestsContext);
    const classes = useStyles();

    useEffect(() => {
        if (user) {
            getAllComments(user.token).then((res) => setRows(res));
        } else {
            setRows([]);
        }
    }, [user]);

    return (
        <Grid className={classes.root}>
            {rows.map((row) => {
                console.log(row);
                console.log(row.userId);
                console.log(user.id)
                console.log(row.userId === user?.id);
                return (
                    <Card key={row.id} className={classes.card} variant="outlined">
                        <CardContent>
                            <Typography variant="h5" component="h2">
                                {row.header}
                            </Typography>
                            <Typography variant="body2" component="p">
                                {row.text}
                            </Typography>
                        </CardContent>
                        {user?.id === row.userId ? (
                            <CardActions>
                                <IconButton>
                                    <DeleteIcon />
                                </IconButton>
                                <IconButton>
                                    <EditIcon />
                                </IconButton>
                            </CardActions>
                        ) : (null)}
                    </Card>
                );
            })}
        </Grid>
    );
}

export default CommentsPage;