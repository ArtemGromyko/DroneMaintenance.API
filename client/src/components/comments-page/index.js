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
    titleUser: {
        fontSize: 14,
    },
    titleAdmin: {
        fontSize: 14,
        color: '#2196F3'
    },
    pos: {
        marginBottom: 12,
    },
    createCommentButton: {
        background: 'linear-gradient(45deg, #2196F3 30%, #21CBF3 90%)',
        border: 0,
        borderRadius: 3,
        boxShadow: '0 3px 5px 2px rgba(33, 203, 243, .3)',
        color: 'white',
    },
    buttons: {
        marginTop: '1rem',
    }
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
            <Grid className={classes.buttons} direction='row' container alignItems='center' justifyContent='space-between'>
                <Button className={classes.createCommentButton}>write a comment</Button>
                <Grid>
                    <Button variant="outlined" color="primary">
                        positive
                    </Button>
                    <Button variant="outlined" color="secondary">
                        negative
                    </Button>
                    <Button variant="outlined" disabled>
                        all
                    </Button>
                    <Button variant="outlined" color="primary" href="#outlined-buttons">
                        mine
                    </Button>
                </Grid>
            </Grid>

            {rows.map((row) => {
                return (
                    <Card key={row.id} className={classes.card} variant="outlined">
                        <CardContent>
                            <Grid direction='row' container alignItems='center' justifyContent='space-between'>
                                {row.userRole === 'user' ? (
                                    <Typography className={classes.titleUser} color='textSecondary' gutterBottom>
                                        {row.userName}
                                    </Typography>
                                ) : (
                                    <Typography className={classes.titleAdmin} color='primary' gutterBottom>
                                        {row.userName} (admin)
                                    </Typography>
                                )}
                                <Typography className={classes.title} color='textSecondary' gutterBottom>
                                    {row.date}
                                </Typography>
                            </Grid>
                            <Typography variant='h5' component='h2'>
                                {row.header}
                            </Typography>
                            <Typography variant='body2' component='p'>
                                {row.text}
                            </Typography>
                        </CardContent>
                        {user?.id === row.userId || user?.role === 'admin' ? (
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