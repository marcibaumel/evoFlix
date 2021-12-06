import React, {useState} from 'react'
import * as FaIcons from "react-icons/fa"
import * as FiIcons from "react-icons/fi"
import * as AiIcons from "react-icons/ai"
import { Link } from 'react-router-dom'
import './Navbar.css';
import { IconContext } from 'react-icons';
import logo from "./imgs/evoflix.png"



function Navbar() {
  const [sidebar, setSidebar] = useState(false);

  const showSidebar = () => setSidebar(!sidebar);

  return (
      <>
      <IconContext.Provider value={{ color: '#fff' }}>
        <div className={sidebar ? 'navbar-nav-menu-active' : 'navbar'}>
        <img src={logo} alt="Logo" className="logo-img"/>
          <Link to='#' className='menu-bars'>
            <FiIcons.FiLogIn onClick={showSidebar} />
          </Link>
        </div>
        <IconContext.Provider value={{ color: '#419D5D' }}>
        <nav className={sidebar ? 'nav-menu active' : 'nav-menu'}>
          <ul className='nav-menu-items' onClick={showSidebar}>
            <li className='navbar-toggle'>
              <Link to='#' className='menu-bars'>
                <AiIcons.AiOutlineClose/>
              </Link>
            </li>
            <div>
                
            </div>
          </ul>
        </nav>
        </IconContext.Provider>
      </IconContext.Provider>
    </>
  );
}

export default Navbar;