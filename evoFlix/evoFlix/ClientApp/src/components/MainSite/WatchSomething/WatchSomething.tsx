import React, {useState, useEffect} from 'react'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import { Grid, Paper, makeStyles } from '@material-ui/core';
import './WatchSomething.css';
import $ from 'jquery';

function WatchSomething() {

    const [films, setFilms] = useState([]);

    useEffect(() => {
        fetch("./Film/getAllFilm")
        .then(res  => res.json())
        .then(data =>  setFilms(data));
    }, []);



    return (
        <>
        <div className='body'>
            <div className="menu">
                <div className="sticky-search">
                    <h2>Filter</h2>
                    <input type='text' value='Filter by text'/>
                </div>
            </div>
            <div className="film-container">
                <Grid container direction='row'>
                    {films.map(film => (
                        <Grid key={film.Id} className='film-item'>
                            <button name={film.title}>
                                <img src={film.poster}/>
                                <p>{film.title}</p>
                            </button>
                        </Grid>
                    ))}
                </Grid>
            </div>
        </div>
        
        </>
    );
}

export default WatchSomething;