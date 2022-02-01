import React, {useState, useEffect, MouseEvent} from 'react';
import { Grid, Button } from '@material-ui/core';
import { FaArrowLeft , FaPlay} from "react-icons/fa"
import './WatchSomething.css';
import $ from 'jquery';
import { useHistory } from 'react-router-dom';

function WatchSomething() {

    let history = useHistory();

    $(document).ready(function(){
        $('#filmBody').show();
        $('#detailsBody').hide();
    });

    const backClick = () => {
        $('#detailsBody').hide();
        $('#filmBody').show();
    };

    const handleClick = (event: React.MouseEvent<HTMLElement>, text: JSON) => {
        console.log(text);
        //hibát jelez de nem hibás
        $('#poster').attr("src",text['poster']);
        $('#title').text(text['title']);
        $('#releaseYear').text(text['releaseYear'].split('-')[0]);
        $('#directors').text(text['directorName']);
        $('#actors').text(text['actors']);
        $('#genre').text(text['genre']);
        $('#rated').text(text['rated']);
        $('#imdbRating').text(text['imdbRating']);
        $('#plot').text(text['plot']);
        $('#filmBody').hide();
        $('#detailsBody').show();
    };

    const [films, setFilms] = useState([]);

    useEffect(() => {
        fetch("./Film/getAllFilm")
        .then(res  => res.json())
        .then(data =>  setFilms(data));
    }, []);

    useEffect(() => {
        fetch("./users/user")
        .then(function(response){
            if(response.status == 401){
                alert("You have to login first!");
                history.push("/");
            }
            else{
                return response.json();
            }})
    });

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
                        <p><b>Rated: </b><span id="rated"></span></p>
                        <p><b>IMDB rating: </b><span id="imdbRating"></span></p>
                        <p><b>Plot: </b><span id="plot"></span></p>
                    </div>
                </div>
                <div id="filmButtons">
                    <Button color="primary" variant="contained">Add to MyList</Button>
                    <Button color="primary" variant="contained" startIcon={<FaPlay />}>Watch this film</Button>
                </div>
            </div>
            
        </div>
        
        </>
    );
}

export default WatchSomething;