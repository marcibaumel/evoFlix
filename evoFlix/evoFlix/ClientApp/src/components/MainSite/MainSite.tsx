import React, {useState} from 'react'
import * as FaIcons from "react-icons/fa"
import * as FiIcons from "react-icons/fi"
import * as AiIcons from "react-icons/ai"
import { Link } from 'react-router-dom'
import './MainSite.css';
import { IconContext } from 'react-icons';
import logo from "./imgs/evoflix.png"
import Login from './Login/Login'




function MainSite() {
  const [sidebar, setSidebar] = useState(false);

  const showSidebar = () => setSidebar(!sidebar);

  return (
      <>
      <IconContext.Provider value={{ color: '#fff' }}>
        <div className={sidebar ? 'wrapper-navbar-nav-menu-active' : 'wrapper'}>
        <div className={sidebar ? 'navbar-nav-menu-active' : 'navbar'}>
        <img src={logo} alt="Logo" className="logo-img"/>
          <Link to='#' className='menu-bars'>
            <FiIcons.FiLogIn onClick={showSidebar} />
          </Link>
        </div>

        <div>
          <h1 className="welcomeText">---------Welcome in the frontpage---------</h1>
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