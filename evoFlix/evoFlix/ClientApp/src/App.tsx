import React from "react";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Navbar from './components/Navbar';
import MainPage from "./components/MainPage";


const App = () => {
  return (
    <>
    <Router> 
      <MainPage/>
       <Switch>
         <Route path='/'/>
       </Switch>
    </Router>
    </>
  );
};

export default App;
