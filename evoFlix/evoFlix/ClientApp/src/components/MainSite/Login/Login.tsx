import React, { useEffect, useState } from "react";
import './Login.css';
 
const Login = () => {
 
    const [user, setUser] = useState({
        email: '',
        password: '',
    });
 
    const [success, setSuccess] = useState(false);
 
 
    const handleChange = (e: { target: { name: any; value: any; }; }) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }
 
/*
    useEffect(() => {
        fetch("http://localhost:8000/users")
        .then(res  => {
          return res.json();
        })
        .then(data => {
          setUser(data);
        });
    }, []);
*/
    const handleLogin = () =>{
        console.log(user.email, user.password);
        alert(user.email);
    }

    return (
        
 
        <div className="centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form id="registrationForm">
                <div className="input-box">
                    <input className="form-block" type="text" name="email" value={user.email} placeholder="Email address" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input className="form-block" type="password" name="password" value={user.password} placeholder="Password" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input type="submit" onClick={handleLogin}/>
                </div>
                
            </form>
        </div>
    );
}
 
export default Login;