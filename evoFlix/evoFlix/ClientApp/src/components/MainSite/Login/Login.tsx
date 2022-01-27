import React, { useEffect, useState } from "react";
import './Login.css';
 
const Login = () => {
 
    const [user, setUser] = useState({
        username: '',
        password: '',
    });
 
    const [success, setSuccess] = useState(false);
 
 
    const handleChange = (e: { target: { name: any; value: any; }; }) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }
 

    const handleLogin = () =>{
        console.log(user.username, user.password);
        
        fetch('./Users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({username: user.username, password: user.password })
        }).then(function(response){
            if(response.status == 200 || response.status == 201){
                alert(user.username)
                setSuccess(true);
            }
            else{
                setSuccess(false);
                alert("Something not seems to be okay with your login data")
            }
        })

        user.username=""
        user.password="" 
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

    return (
     
        
        <div className="centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form id="registrationForm">
                <div className="input-box">
                    <input className="form-block" type="text" name="username" value={user.username} placeholder="Username" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input className={checkPasswordFormat(user.password) ? "form-block" : "form-block-wrong"} type="password" name="password" value={user.password} placeholder="Password" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input type="button" onClick={handleLogin} value="Login"/>
                </div>
                
            </form>
        </div>
        
       
    
    );
}
 
export default Login;