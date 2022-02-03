import React, {useState, useEffect, MouseEvent} from 'react';
import { Grid } from '@material-ui/core';
import { FaArrowLeft} from "react-icons/fa"
import './WatchSomething.css';
import $ from 'jquery';
import Player from '../../Videoplayer/Player';

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

    const [query, setQuery] = useState<string>('')


    useEffect(() => {
        var filmQuery = "./Film/getFilms?genre=" + query;
        console.log(filmQuery)
        fetch(filmQuery)
        .then(res  => res.json())
        .then(data =>  setFilms(data));
    }, [query]);
    
    const handleFilter = (event: any) =>  {
        var query = $('#selectedGenre').val().toString();
        setQuery(query);
    }

    return (
        <>
        <div id="filmBody">
            <div className="menu">
                <div className="sticky-search">
                    <h2>Filter</h2>
                    <form onChange={(e) => handleFilter(e)}>
                        <select id="selectedGenre">
                            <option selected value="">Select a genre</option>
                            <option value="Action">Action</option>
                            <option value="Comedy">Comedy</option>
                            <option value="Animation">Animation</option>
                            <option value="Adventure">Adventure</option>
                            <option value="Horror">Horror</option>
                            <option value="Drama">Drama</option>
                            <option value="Sci-Fi">Sci-Fi</option>
                            <option value="Thriller">Thriller</option>
                            <option value="Crime">Crime</option>
                            <option value="Fantasy">Fantasy</option>
                            <option value="War">War</option>
                        </select>
                    </form>
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