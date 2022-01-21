import React, {useState, useRef} from "react";
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography  from "@material-ui/core/Typography";
import Container  from "@material-ui/core/Container";
import ReactPlayer from 'react-player'
import { makeStyles } from '@material-ui/core/styles'
import PlayerControls from "./Controls/PlayerControls";
import screenfull from "screenfull";
import { Bookmarks } from "@material-ui/icons";
import  Grid  from "@material-ui/core/Grid";
import Paper  from "@material-ui/core/Paper";

const useStyles = makeStyles({
  playerWrapper:{
    width:"100%",
    position:"relative"
  },
})

const format = (seconds:any) => {
  if (isNaN(seconds)) {
    return `00:00`;
  }
  const date = new Date(seconds * 1000);
  const hh = date.getUTCHours();
  const mm = date.getUTCMinutes();
  const ss = date.getUTCSeconds().toString().padStart(2, "0");
  if (hh) {
    return `${hh}:${mm.toString().padStart(2, "0")}:${ss}`;
  }
  return `${mm}:${ss}`;
};

function App() {
  const classes = useStyles();
  const [state, setState] = useState({
    playing:true,
    muted:false,
    volume: 0.5,
    playbackRate: 1.0,
    played:0,
    seeking:false,

  })

  const [timeDisplayFormat, setTimeDisplayFormat] = useState("normal")

  const {playing, muted, volume, playbackRate, played, seeking} = state;
  //const [bookmark, setBookmarks] = useState([]);


  const addBookmark = () => {
    const canvas = canvasRef.current
    canvas.width = 160
    canvas.height = 90
  }

  const handleRewind = () => {
    playerRef.current.seekTo(playerRef.current.getCurrentTime() - 10)
  }

  const handleFastForward = () => {
    playerRef.current.seekTo(playerRef.current.getCurrentTime() + 10)
  }
  var count = 0;
  const playerRef = useRef(null);
  const canvasRef = useRef(null);
  const controlsRef = useRef(null);

  /*
  const handlePlayePause : void = () => {
    setState({...state, playing: !state.playing});
  }
  */

  function handlePlayePause() : void{

  }

  const handleMute = () => {
    setState({...state, muted:!state.muted});
  }

  const handleVolumeChange = (e:any, newValue:any) => {
    setState({...state, 
            volume: parseFloat((newValue / 100).toString()),
            muted: newValue === 0 ? true : false,
    })
  }

  const handleProgress = (changeState:any) => {
    if (count > 3) {
      controlsRef.current.style.visibility = "hidden";
      count = 0;
    }
    if (controlsRef.current.style.visibility == "visible") {
      count += 1;
    }
    if (!state.seeking) {
      setState({ ...state, ...changeState });
    }
  };

  const handleVolumeSeekUp = (e:any, newValue:any) => {
    setState({...state, 
      volume: parseFloat((newValue / 100).toString()),
      muted: newValue === 0 ? true : false,
    })
  }

  const handlePlaybackRateChange = (rate:any) =>{
    setState({...state, playbackRate: rate})
  }

  const toggleFullScreen = () =>(
    screenfull.toggle(playerContainerRef.current)
  )


  const handleSeekChange = (e:any, newValue:any) => {
    setState({...state, played:parseFloat((newValue / 100).toString())});
  }

  const handleSeekMouseDown = (e:any) => {
    setState({...state, seeking:true})
  }

  const handleSeekMouseUp = (e:any, newValue:any) => {
    setState({...state, seeking:false});
    playerRef.current.seekTo(newValue / 100);
  }

  const currentTime = playerRef.current ? playerRef.current.getCurrentTime() : '00:00'
  const duration = playerRef.current? playerRef.current.getDuration() : "00:00";
  const elapsedTime = timeDisplayFormat ==='normal' ? format(currentTime) 
      : `${format(duration-currentTime)}`;
  const totalDuration = format(duration);

  const handleChangeDisplayFormat = () =>{
    setTimeDisplayFormat(timeDisplayFormat ==='normal'?'remmaining':'normal')
  }

  const handleMouseMove = () =>{
    console.log("mousemove");
    controlsRef.current.style.visibility = "visible";
    count = 0;
  }

  const hanldeMouseLeave = () => {
    controlsRef.current.style.visibility = "hidden";
    count = 0;
  };


  const playerContainerRef = useRef(null)

return (
   <>
   <Toolbar/>
   <Container maxWidth="lg">
   <div
          onMouseMove={handleMouseMove}
          onMouseLeave={hanldeMouseLeave}
          ref={playerContainerRef}
          className={classes.playerWrapper}
        >
      <ReactPlayer
      ref={playerRef}
      width={"100%"}
      height="100%"
        //url="http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
        //url="https://www.youtube.com/watch?v=y0eLg5-hXI0&ab_channel=Cinemassacre"
        url='videos/test.mp4'
        muted={muted}
        playing={playing}
        volume={volume}
        playbackRate={playbackRate}
        onProgress={handleProgress}
      />


      <PlayerControls
        ref={controlsRef}
        onPlayPause = {handlePlayePause}
        playing={playing}
        onRewind = {handleRewind}
        onFastForward = {handleFastForward}
        muted={muted}
        onMute={handleMute}
        onVolumeChange={handleVolumeChange}
        onVolumeSeekUp={handleVolumeSeekUp}
        volume={volume}
        playbackRate = {playbackRate}
        onPlayBackRateChange = {handlePlaybackRateChange}
        onToggleFullScreen = {toggleFullScreen}
        played={played}
        onSeek={handleSeekChange}
        onSeekMouseDown={handleSeekMouseDown}
        onSeekMouseUp={handleSeekMouseUp}
        elapsedTime={elapsedTime}
        totalDuration={totalDuration}
        onChangeDisplayFormat = {handleChangeDisplayFormat}
        //onBookmark = {addBookmark}
      />
    </div>
    {/* 
   <Grid container style={{marginTop:20}} spacing={3}>
    {Bookmarks.map((bookmark, index) => (
      <Grid item key={index}>
        <Paper>
          <img crossOrigin="anonymous" src="" />
          <Typography>Bookmark at 00:00</Typography>
        </Paper>
      </Grid>
    ))}
   </Grid>

    <canvas ref={canvasRef}/>
    */}
   </Container>
   </>
  );
}

export default App;
