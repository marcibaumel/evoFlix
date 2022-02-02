import React, {useState, useEffect, MouseEvent} from 'react';
import { Grid, Button } from '@material-ui/core';
import {BrowserRouter as Router, Route} from 'react-router-dom'
import { FaArrowLeft , FaPlay} from "react-icons/fa"
import './WatchSomething.css';
import $ from 'jquery';
import { useHistory } from 'react-router-dom';
import Player from '../../Videoplayer/Player';
import { text } from 'stream/consumers';
import NewWindow from 'react-new-window'

function WatchSomething() {


    const [playing, setPlaying] = useState('false')
    const [source, setSource] = useState('')


    $(document).ready(function(){
        $('#filmBody').show();
        $('#detailsBody').hide();
        $('#playerBody').hide();
    });

    const backClick = () => {
        $('#detailsBody').hide();
        $('#playerBody').hide();
        setPlaying('false')
        $('#filmBody').show();
    };

    

    const handleClick = (event: React.MouseEvent<HTMLElement>, text: any) => {
        console.log(text);
        $('#poster').attr("src",text['poster']);
        $('#title').text(text['title']);
        $('#releaseYear').text(text['releaseYear'].split('-')[0]);
        $('#directors').text(text['directorName']);
        $('#actors').text(text['actors']);
        $('#genre').text(text['genre']);
        $('#source').text(text['source']);
        //$('#rated').text(text['rated']);
        console.log(text['source'])
        setSource(text['source'])
        console.log(source)
        $('#imdbRating').text(text['imdbRating']);
        $('#plot').text(text['plot']);
        $('#filmBody').hide();
        $('#detailsBody').show();
    };

    const [films, setFilms] = useState([]);

    function openPlayer():any{
        console.log("PLAYER")
        setPlaying('true')
    }

    const AddTripButton = (props:any) => {
        return <button onClick={props.addTrip}>{props.msg}</button>
      }

    useEffect(() => {
        fetch("./Film/getAllFilm")
        .then(res  => res.json())
        .then(data =>  setFilms(data));
    }, []);
    

    return (
        <>
        <div id="filmBody">
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
                            <button onClick={(e) => handleClick(e, film)}>
                                <img src={film.poster}/>
                                <p>{film.title}</p>
                            </button>
                        </Grid>
                    ))}
                </Grid>
            </div>
        </div>

        

        <div id="detailsBody">
            <div id="backButton">
                <FaArrowLeft color="black" size="50px" onClick={backClick}/>
            </div>
            <div id="filmDetails">
                <h1><span id="title"></span> (<span id="releaseYear"></span> )</h1>
                <div>
                    <img id="poster"/>
                    <div id="details">
                        <p><b>Director(s): </b><span id="directors"></span></p>
                        <p><b>Actors: </b><span id="actors"></span></p>
                        <p><b>Genre: </b><span id="genre"></span></p>
                        {/*<p><b>Rated: </b><span id="rated"></span></p>*/}
                        <p><b>IMDB rating: </b><span id="imdbRating"></span></p>
                        <p><b>Plot: </b><span id="plot"></span></p>
                        <p><b>Source: </b><span id="source"></span></p>
                    </div>
                </div>
                <div id="filmButtons">
                    {/*<Button color="primary" variant="contained">Add to MyList</Button>*/}
                    {/*<AddTripButton addTrip={() => setPlaying('true')} msg="Play" />*/}
                    <div>
                        <Player filmSource={source}/>
                    </div>
                </div>
            </div>
        </div>

        </>
    );
}

export default WatchSomething;