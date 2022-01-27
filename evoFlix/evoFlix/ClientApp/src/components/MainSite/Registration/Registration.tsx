import React, { useEffect, useState } from "react";
import {Link} from 'react-router-dom';
import './Registration.css'
 
const Registration = () => {
 
    // States for registration
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [password2, setPassword2] = useState('');
  const [birthday, setBirthday] = useState('');
  
  const [submitted, setSubmitted] = useState(false);
  const [error, setError] = useState(false);
 
 
  const handleName = (e:any) => {
    setUsername(e.target.value);
    setSubmitted(false);
  };
 
  
  const handleEmail = (e:any) => {
    setEmail(e.target.value);
    if(checkEmailFormat(email) === false){
        console.log("ROSSZ EMAIL")
    }
    setSubmitted(false);
  };
 

  const handlePassword = (e:any) => {
    setPassword(e.target.value);
    setSubmitted(false);
  };

  const handlePassword2 = (e:any) => {
    setPassword2(e.target.value);
    setSubmitted(false);
  };

  const handleBirthday = (e:any) => {
    setBirthday(e.target.value);
    setSubmitted(false);
  };
 
  // Handling the form submission
  const handleSubmit = (e:any) => {
    e.preventDefault();
    if (username === '' ||checkEmailFormat(email) === false ||email.length === 0 || password === '') {
      setError(true);
    } else {
      setSubmitted(true);
      setError(false);
    }
  };

  function checkEmailFormat(email:string): boolean{
    const regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if(email.length === 0)
      return true;
    return regex.test(email);
  }

  function checkPasswordFormat(password:string):boolean{
    //at least a symbol, upper and lower case letters and a number + min 6 letter
    const regex = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{6,}$/;
    if(password.length>0){
      if(regex.test(password)){
        return true
      }
      return false
    }
    return true
  }

  function checkPassword2(password2:string):boolean{
    if(password2.length>0){
      if(password2.localeCompare(password)===0){
        return true
      }
    }
  }

  function checkUsername(username:string):boolean{
    if(username.length == 0){
      return false
    }
    return true
  }
  
 
  return (
    <>
    <div className="container">
      <div className="centerCard">
        <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
        <form>
          <div className="input-box">
            <input className={checkUsername(username) ? "form-block" : "form-block-wrong"} onChange={handleName}  value={username} type="text" placeholder="Username"/>
          </div>
        
          <div className="input-box">
            <input className={checkEmailFormat(email) ? "form-block" : "form-block-wrong"} onChange={handleEmail} value={email} type="email" placeholder="Email"/>
          </div>

          <div className="input-box">
            <input className={checkPasswordFormat(password) ? "form-block" : "form-block-wrong"} onChange={handlePassword} value={password} type="password" placeholder="Password"/>
          </div>

          <div className="input-box">
            <input className={checkPassword2(password2) ? "form-block" : "form-block-wrong"} onChange={handlePassword2} value={password2} type="password" placeholder="Re-Password"/>
          </div>

          <div className="input-box">
            <input className="form-block" onChange={handleBirthday} value={birthday} type="date" placeholder="Birthday"/>
          </div>

          <button onClick={handleSubmit} className="btn" type="submit"> Submit </button>
        </form>
      </div>
    </div>
    </>
  );
}
 
export default Registration;