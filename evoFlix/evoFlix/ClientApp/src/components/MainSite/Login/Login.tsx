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


    async function loginFunction(username:string, password:string) {
        fetch('http://localhost:8000/Users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({username: "Béla", password: "Bél@12" })
        }).then(function(response){
            if(response.status == 200 ||)
        })
        
    }
*/

    const handleLogin = () =>{
        console.log(user.username, user.password);
        
        fetch('http://localhost:8000/Users/login', {
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
        
    }

    return (
        <>
        {success ? (
        <>
            <img src="https://i.pinimg.com/originals/58/22/46/58224674a4868f695d1f0e4ff61bf959.gif" alt="Banner" />
        </>
        ):(
        <>
        
        <div className="centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form id="registrationForm">
                <div className="input-box">
                    <input className="form-block" type="text" name="username" value={user.username} placeholder="Username" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input className="form-block" type="password" name="password" value={user.password} placeholder="Password" onChange={handleChange} />
                </div>

                <div className="input-box">
                    <input type="button" onClick={handleLogin} value="Login"/>
                </div>
                
            </form>
        </div>
        
        </>)}
        </>
    );
}
 
export default Login;