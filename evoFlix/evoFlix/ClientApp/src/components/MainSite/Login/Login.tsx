/*
import React from "react";

function Login(){
    return(
        <>
        <div>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Quibusdam, quasi. Accusantium maxime illo, harum dicta ipsa officiis, aspernatur deleniti quibusdam, asperiores totam a odit architecto eius. Sunt, ipsam. Nostrum, qui!
        </div>
        </>
    )
}

export default Login;
*/

import React, { useEffect, useState } from "react";
import './Login.css';
//import { useForm } from 'react-hook-form';
//import '../Forms.css';
//import validate from "../RegisterPage/RegisterValidate";
 
const Login = () => {
 
    const [user, setUser] = useState({
        email: '',
        password: '',
    });
 
    const [errors, setErrors] = useState({});
 
    const [success, setSuccess] = useState(false);
 
    const [emailExists, setEmailExists] = useState();
 
    const handleChange = (e: { target: { name: any; value: any; }; }) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }
 
    return (
        
 
        <div className="centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form id="registrationForm">
                <div className="input-box">
                <input className="form-block" type="text" name="email" value={user.email} placeholder="Email address" onChange={handleChange} />
                {/*errors.email && <p class="ErrorParagraph">{errors.email}</p>*/}
                {/*emailExists && <p class="ErrorParagraph">Email already exist</p>*/}
                </div>

                <div className="input-box">
                <input className="form-block" type="password" name="password" value={user.password} placeholder="Password" onChange={handleChange} />
                {/*errors.password && <p class="ErrorParagraph">{errors.password}</p>*/}
                </div>

                <div className="input-box">
                    <input type="submit" />
                </div>
                
            </form>
            {/*success && <p class="SuccessParagraph">Student {user.firstname} successfully added.</p>*/}
        </div>
    );
}
 
export default Login;