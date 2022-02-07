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
 
  const handleRegistrationFunction = () =>{
    console.log(username, email, password, password2, birthday);
    if(checkSubmitRequirement() == true){
    fetch('./Users/register', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          username: username,
          email: email,
          password: password,
          birthday: birthday
      })
    }).then(function(response){
        if(response.status == 200 || response.status == 201){
            alert(username)
            setSubmitted(true);
        }
        else{
            setError(true);
            alert("Something not seems to be okay with your registration data")
        }
    })}

    
}

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
    console.log(birthday);
  };
 

  function checkBirthday(birthday:string):boolean{
    if(!birthday){
      return false;
    }
    return true;
  }

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
  

  function checkSubmitRequirement():boolean{
    if(checkUsername(username) && checkPasswordFormat(password) && checkPassword2(password2) && checkEmailFormat(email) && checkBirthday(birthday))
      return true
  }
 
  return (
    <>
    <div className="container">
      <div className="centerCard">
        <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
        <form>
          <div className="input-box">
            <label>Enter your username:</label>
            <input className={checkUsername(username) ? "form-block" : "form-block-wrong"} onChange={handleName}  value={username} type="text" placeholder="Username"/>
          </div>
        
          <div className="input-box">
            <label>Enter your email address:</label>
            <input className={checkEmailFormat(email) ? "form-block" : "form-block-wrong"} onChange={handleEmail} value={email} type="email" placeholder="Email"/>
          </div>

          <div className="input-box">
            <label>Enter your password:</label>
            <input className={checkPasswordFormat(password) ? "form-block" : "form-block-wrong"} onChange={handlePassword} value={password} type="password" placeholder="Password"/>
            <label>(Minimum requirements: 1 uppercase character, 1 special character, 1 number)</label>
          </div>

          <div className="input-box">
            <label>Enter your password again:</label>
            <input className={checkPassword2(password2) ? "form-block" : "form-block-wrong"} onChange={handlePassword2} value={password2} type="password" placeholder="Re-Password"/>
          </div>

          <div className="input-box">
            <label>Give your birthday:</label>
            <input className={checkBirthday(birthday) ? "form-block" : "form-block-wrong"} onChange={handleBirthday} value={birthday} type="Date" placeholder="Birthday"/>
          </div>

          <button disabled={checkSubmitRequirement()==false} onClick={handleRegistrationFunction} className={checkSubmitRequirement() ? "btn" : "btn-disable"} type="button"> Registration </button>
        </form>
      </div>
    </div>
    </>
  );
}
 
export default Registration;