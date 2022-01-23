import React, {useState, useEffect} from 'react'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import { Grid, Paper, makeStyles } from '@material-ui/core';
import './WatchSomething.css';

function WatchSomething() {
    const [films, setFilms] = useState([]);

    useEffect(() => {
        fetch("./Film/getAllFilm")
        .then(res  => res.json())
        .then(data =>  setFilms(data));
    }, []);

    return (
        <>
        <div className="body">
            <div className="menu">
                <h1>This is my menu</h1>
            </div>
            <Grid container direction='row' className="film-container">
                {films.map(film => (
                    <Grid className='film-item'>
                        <img src={film.poster}/>
                        <p>{film.title}</p>
                    </Grid>
                ))}
            </Grid>
        </div>
        
        </>
    );
}

export default WatchSomething;