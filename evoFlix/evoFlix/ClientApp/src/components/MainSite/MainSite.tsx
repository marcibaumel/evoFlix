import React, {useEffect, useState} from 'react'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import * as FaIcons from "react-icons/fa"
import * as FiIcons from "react-icons/fi"
import * as AiIcons from "react-icons/ai"
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Link } from 'react-router-dom'
import './MainSite.css';
import { IconContext } from 'react-icons';
import logo from "./Resources/imgs/evoflix2.png"
import Login from './Login/Login'
import { Carousel } from 'react-responsive-carousel'
import Registration from './Registration/Registration';
import WatchSomething from './WatchSomething/WatchSomething'
import ProfileSettings from './ProfileSettings/ProfileSettings'
import Player from '../Videoplayer/Player'



function MainSite() {

  const [sidebar, setSidebar] = useState(false);
  const [user, setUser] = useState();
  const [state, setState] = useState('login');
  const [loggedIn, setLoggedIn] = useState(false);

  const AddTripButton = (props:any) => {
    return <button onClick={props.addTrip}>{props.msg}</button>
  }

  const showSidebar = () => setSidebar(!sidebar);

    const handleLogin = function (value: boolean) {
        setLoggedIn(value);
    }

    
    useEffect(() => {
        fetch("./users/user")
            .then(res => res.json())
            .catch((reason) => {
               console.log(reason);
            })
            .then(data => setUser(data))
            .finally(() => {
                if (user !== null && user !== undefined) {
                    setLoggedIn(true);
                }
                else {
                    setLoggedIn(false);
                }
            });
    }); 
   

  return (
      <>  
      <Router>
      <IconContext.Provider value={{ color: '#fff' }}>
        <div className={sidebar ? 'wrapper-navbar-nav-menu-active' : 'wrapper'}>
          <div className={sidebar ? 'navbar-nav-menu-active' : 'navbar'}>
            <button className="navbar-button"><Link className="navbar-link" to='/'>Home</Link></button>
            <button className="navbar-button"><Link className="navbar-link" to='/watchsomething'>Watch Something</Link></button>
            <img src={logo} alt="Logo" className="logo-img"/>
            {(() => {
                if (loggedIn === false)
                    return (
                        <Link to='#' className='menu-bars'>
                            <FiIcons.FiLogIn onClick={showSidebar} />
                        </Link>
                    );
                else {
                    return (
                        <button className="navbar-button">
                            <Link className="navbar-link" to='/profilesettings'>Profile</Link>
                        </button>
                    );
                }
            })()}
        </div>

        <Route path='/' exact render={(props)=>(
              <>
                <div>
                  <h1 className="welcomeText">Unlimited movies, TV shows, and more.</h1>
                  <h2 className="welcomeText"> Watch anywhere. Cancel anytime</h2>
                  <h2 className="welcomeText">Ready to watch? Press the button in the<a onClick={showSidebar}><span className="to-the-button-text">right corner.</span></a></h2>
                  <div className="imgCarousel-div">
                    <Carousel className="imgCarousel" 
                      showStatus={false} 
                      infiniteLoop={true} 
                      autoPlay={true}>
                        <div>
                            <img src="https://variety.com/wp-content/uploads/2021/03/Shrek-Eddie-Murphy-1.jpg" alt="m1"/>
                            <p className="legend">Shrek</p>
                        </div>
                        <div>
                            <img src="https://www.indiewire.com/wp-content/uploads/2021/10/MCDBEMO_EC001.jpg?w=780" alt="m2"/>
                            <p className="legend">Bee Movie</p>
                        </div>
                        <div>
                            <img src="https://ntvb.tmsimg.com/assets/p20115224_v_h8_aa.jpg?w=1280&h=720" alt="m3"/>
                            <p className="legend">Kate</p>
                        </div>
                    </Carousel>
                  </div>
                  {/*<Player filmSource="./video/test.mp4"/>*/}
                </div>
              </>
            )}/>
            <Route path='/watchsomething' component={WatchSomething}/>
            <Route path='/profilesettings' component={ProfileSettings} />

                  </div>
                  <IconContext.Provider value={{ color: '#419D5D' }}>
                      <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
                          <ul className='nav-menu-items' >
                              <li className='navbar-toggle'>
                                  <Link to='#' className='menu-bars'>
                                      <AiIcons.AiOutlineClose onClick={showSidebar} />
                                  </Link>
                              </li>
                              <div>
                                  {state === 'login' && (
                                      <>
                                          <AddTripButton addTrip={() => setState('registration')} msg="Registration" />
                                          <Login loginFunction={handleLogin} />
                                      </>
                                  )}
                                  {state === 'registration' && (
                                      <>
                                          <AddTripButton addTrip={() => setState('login')} msg="Login" />
                                          <Registration />
                                      </>
                                  )}
                              </div>

                          </ul>
                      </nav>
                  </IconContext.Provider>
            
          </IconContext.Provider>
      </Router>
    </>
  );
}

export default MainSite;