import React from "react";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Navbar from './components/MainSite/MainSite';


const App = () => {
  return (
    <>
    <Router>
       <Navbar/>
       <Switch>
         <Route path='/'/>
       </Switch>
    </Router>
    </>
  );
};


export default App;
