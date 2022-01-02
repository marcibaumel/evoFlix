import React, {useState} from "react";
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

  })

  const {playing} = state;

  const handlePlayePause = () =>{
    setState({...state, playing: !state.playing});
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
      width={"100%"}
      height="100%"
        url="http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"
        muted={true}
        playing={playing}
      />


      <PlayerControls
        onPlayPause = {handlePlayePause}
        playing={playing}
      />
    </div>
      
   </Container>
   </>
  );
}

export default App;
