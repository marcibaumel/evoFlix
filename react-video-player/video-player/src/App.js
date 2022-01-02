import React, {useState, useRef} from "react";
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography  from "@material-ui/core/Typography";
import Container  from "@material-ui/core/Container";
import ReactPlayer from 'react-player'
import { makeStyles } from '@material-ui/core/styles'
import PlayerControls from "./components/PlayerControls";


const useStyles = makeStyles({
  playerWrapper:{
    width:"100%",
    position:"relative"
  },
})



function App() {
  const classes = useStyles();
  const [state, setState] = useState({
    playing:true,
    muted:true,
  })

  const {playing, muted} = state;

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

  return (
   <>
   <AppBar position="fixed">
     <Toolbar>
        <Typography variant="h6">React Video Player</Typography>
     </Toolbar>
   </AppBar>
   <Toolbar/>
   <Container maxWidth="md">
     <div className={classes.playerWrapper}>
      <ReactPlayer
      ref={playerRef}
      width={"100%"}
      height="100%"
        //url="http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
        //url="https://www.youtube.com/watch?v=y0eLg5-hXI0&ab_channel=Cinemassacre"
        url='videos/test.mp4'
        muted={muted}
        playing={playing}
      />


      <PlayerControls
        onPlayPause = {handlePlayePause}
        playing={playing}
        onRewind = {handleRewind}
        onFastForward = {handleFastForward}
        muted={muted}
        onMute={handleMute}
      />
    </div>
      
   </Container>
   </>
  );
}

export default App;
