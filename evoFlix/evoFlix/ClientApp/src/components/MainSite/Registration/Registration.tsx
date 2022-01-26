import React, { useEffect, useState } from "react";
import {Link} from 'react-router-dom';
import './Registration.css'
 
const Registration = () => {
 
    // States for registration
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
 
  
  const [submitted, setSubmitted] = useState(false);
  const [error, setError] = useState(false);
 
 
  const handleName = (e:any) => {
    setName(e.target.value);
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
 
  // Handling the form submission
  const handleSubmit = (e:any) => {
    e.preventDefault();
    if (name === '' ||checkEmailFormat(email) === false || password === '') {
      setError(true);
    } else {
      setSubmitted(true);
      setError(false);
    }
  };

  function checkEmailFormat(email:string): boolean{
    const regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(email);
  }
 
  // Showing success message
  const successMessage = () => {
    return (
      <div
        className="success"
        style={{
          display: submitted ? '' : 'none',
        }}>
        <h1>User {name} successfully registered!!</h1>
      </div>
    );
  };
 
  // Showing error message if error is true
  const errorMessage = () => {
    return (
      <div
        className="error"
        style={{
          display: error ? '' : 'none',
        }}>
        <h1>Please enter all the fields</h1>
      </div>
    );
  };
 
  return (
    <div className="form">
      <div>
        <h1>User Registration</h1>
      </div>
 
      {/* Calling to the methods */}
      <div className="messages">
        {errorMessage()}
        {successMessage()}
      </div>
 
      <form>
        <input onChange={handleName} className="input" value={name} type="text" />
        <input onChange={handleEmail} className="input" value={email} type="email" />
        <input onChange={handlePassword} className="input" value={password} type="password" />
 
        <button onClick={handleSubmit} className="btn" type="submit"> Submit </button>
      </form>
    </div>
  );
}
 
export default Registration;