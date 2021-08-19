import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import { Grid, Paper, Typography, Card } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core';
import { useHistory } from 'react-router';
import { MainContext } from '../../contexts/main-context';

const useStyles = makeStyles({
    root: {
        width: '70%',
        minHeight: '75px',
        margin: '0 auto'
    },
    link: {
        color: '#000000',
        textDecoration: 'none',
        "&:hover": {
            color: "#2196F3"
        }
    },
    button: {
        background: 'linear-gradient(45deg, #2196F3 30%, #21CBF3 90%)',
        border: 0,
        borderRadius: 3,
        boxShadow: '0 3px 5px 2px rgba(33, 203, 243, .3)',
        color: 'white',
        height: 48,
        padding: '0 30px',
        margin: 8,
    },
});

const Header = () => {
    const { jwt } = useContext(MainContext);
    const { setJwt } = useContext(MainContext);
    const history = useHistory();
    const classes = useStyles();

    return (
        <Card variant='outlined'>
            <Typography>
                <Grid className={classes.root} direction='row' container alignItems='baseline' justifyContent="space-between">
                    <h1>
                        <Link className={classes.link} to="/">
                            Drone Maintenance
                        </Link>
                    </h1>
                    {jwt === '' ? (
                        <Button className={classes.button} onClick={() => history.push('/login')}>Sign in</Button>
                    ) : (null)}
                    {/* <Button className={classes.button} onClick={() => history.push('/login')}>Sign in</Button> */}
                </Grid>
            </Typography>
        </Card>
    );
};

export default Header;