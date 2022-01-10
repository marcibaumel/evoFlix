import React, {useState, useRef} from "react";
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography  from "@material-ui/core/Typography";
import Container  from "@material-ui/core/Container";
import ReactPlayer from 'react-player'
import { makeStyles } from '@material-ui/core/styles'
import PlayerControls from "./components/PlayerControls";
import screenfull from "screenfull";

const useStyles = makeStyles({
  playerWrapper:{
    width:"100%",
    position:"relative"
  },
})

const format = (seconds) => {
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
    muted:true,
    volume: 0.5,
    playbackRate: 1.0,
    played:0,
    seeking:false,

  })

  const [timeDisplayFormat, setTimeDisplayFormat] = useState("normal")

  const {playing, muted, volume, playbackRate, played, seeking} = state;


  const handleRewind = () => {
    playerRef.current.seekTo(playerRef.current.getCurrentTime() - 10)
  }

  const handleFastForward = () => {
    playerRef.current.seekTo(playerRef.current.getCurrentTime() + 10)
  }

  const playerRef = useRef(null);

  const handlePlayePause = () => {
    setState({...state, playing: !state.playing});
  }

  const handleMute = () => {
    setState({...state, muted:!state.muted});
  }

  const handleVolumeChange = (e, newValue) => {
    setState({...state, 
            volume: parseFloat(newValue / 100),
            muted: newValue === 0 ? true : false,
    })
  }

  const handleProgress = (changeState) => {
    console.log(changeState)

    if(!state.seeking){
      setState({...state, ...changeState});
    }
  }

  const handleVolumeSeekUp = (e, newValue) => {
    setState({...state, 
      volume: parseFloat(newValue / 100),
      muted: newValue === 0 ? true : false,
    })
  }

  const handlePlaybackRateChange = (rate) =>{
    setState({...state, playbackRate: rate})
  }

  const toggleFullScreen = () =>(
    screenfull.toggle(playerContainerRef.current)
  )


  const handleSeekChange = (e, newValue) => {
    setState({...state, played:parseFloat(newValue / 100)});
  }

  const handleSeekMouseDown = (e) => {
    setState({...state, seeking:true})
  }

  const handleSeekMouseUp = (e, newValue) => {
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

  const playerContainerRef = useRef(null)

  return (
   <>
   {/*
   <AppBar position="fixed">
     <Toolbar>
        <Typography variant="h6">React Video Player</Typography>
     </Toolbar>
   </AppBar>
   */}
   <Toolbar/>
   <Container maxWidth="lg">
     <div ref={playerContainerRef} className={classes.playerWrapper}>
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
      />
    </div>
      
   </Container>
   </>
  );
}

export default App;
