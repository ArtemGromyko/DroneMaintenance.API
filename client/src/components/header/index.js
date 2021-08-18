import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Avatar, Grid, Paper } from '@material-ui/core';

import './header.css';

const Header = () => {
    return (
        <Grid style={{width:'70%'}} className='header' direction='row' container alignItems='baseline' justifyContent="space-between">
            <h1>
                <Link to="/">
                    Drone Maintenance
                </Link>
            </h1>
            <Link to="/login">Sign in</Link>
        </Grid>
    );
};

export default Header;