import React, {useState} from 'react'
import * as FaIcons from "react-icons/fa"
import * as FiIcons from "react-icons/fi"
import * as AiIcons from "react-icons/ai"
import "react-responsive-carousel/lib/styles/carousel.min.css";
import { Link } from 'react-router-dom'
import './MainSite.css';
import { IconContext } from 'react-icons';
import logo from "./imgs/evoflix.png"
import Login from './Login/Login'
import { Carousel } from 'react-responsive-carousel'





function MainSite() {
  const [sidebar, setSidebar] = useState(false);

  const showSidebar = () => setSidebar(!sidebar);

  const test = () => console.log("Gomb");

  return (
      <>

      
      
      <IconContext.Provider value={{ color: '#fff' }}>
        <div className={sidebar ? 'wrapper-navbar-nav-menu-active' : 'wrapper'}>
        <div className={sidebar ? 'navbar-nav-menu-active' : 'navbar'}>
        <button onClick={test} className="navbar-button">Home</button>
        <button onClick={test} className="navbar-button">Watch something</button>
        <img src={logo} alt="Logo" className="logo-img"/>
          <Link to='#' className='menu-bars'>
            <FiIcons.FiLogIn onClick={showSidebar} />
          </Link>
        </div>

        <div>
          <h1 className="welcomeText">Unlimited movies, TV shows, and more.</h1>
          <h2 className="welcomeText"> Watch anywhere. Cancel anytime</h2>
          <h2 className="welcomeText">Ready to watch? Press the button in the<a onClick={showSidebar}><span className="to-the-button-text">right corner.</span></a></h2>
          <div className="imgCarousel-div">
          <Carousel className="imgCarousel">
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
        </div>


        </div>
        <IconContext.Provider value={{ color: '#419D5D' }}>
        <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
          <ul className='nav-menu-items' >
            <li className='navbar-toggle'>
              <Link to='#' className='menu-bars'>
                
                <AiIcons.AiOutlineClose onClick={showSidebar}/>
              </Link>
            </li>
            <div>
                <Login/> 
            </div>
          </ul>
        </nav>
        </IconContext.Provider>
      </IconContext.Provider>
      {/*<div className={sidebar ? "additional-content-active-navbar" : "additional-content"}></div>*/}
    </>
  );
}

export default MainSite;