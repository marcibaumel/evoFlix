import React, { useEffect, useState } from "react";
import {Link} from 'react-router-dom';
 
const Registration = () => {
 
    const [user, setUser] = useState({
        username: '',
        birth: '',
        email: '',
        password: '',
        password2: ''
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
        <>
        <div className="centerCard">
        <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
        <form id="registrationForm">

            <div className="input-box"> 
            <input className="form-block" type="text" name="username" value={user.username} placeholder="Username" onChange={handleChange} />
            {/*errors.email && <p class="ErrorParagraph">{errors.email}</p>*/}
            {/*emailExists && <p class="ErrorParagraph">Email already exist</p>*/}
            </div>

            <div className="input-box"> 
            <input className="form-block" type="date" name="birth" value={user.birth} placeholder="Birth" onChange={handleChange} />
            {/*errors.email && <p class="ErrorParagraph">{errors.email}</p>*/}
            {/*emailExists && <p class="ErrorParagraph">Email already exist</p>*/}
            </div>

            <div className="input-box"> 
            <input className="form-block" type="email" name="email" value={user.email} placeholder="Email address" onChange={handleChange} />
            {/*errors.email && <p class="ErrorParagraph">{errors.email}</p>*/}
            {/*emailExists && <p class="ErrorParagraph">Email already exist</p>*/}
            </div>

            <div className="input-box">
            <input className="form-block" type="password" name="password" value={user.password} placeholder="Password" onChange={handleChange} />
            {/*errors.password && <p class="ErrorParagraph">{errors.password}</p>*/}
            </div>

            <div className="input-box">
            <input className="form-block" type="password" name="password2" value={user.password} placeholder="Password again" onChange={handleChange} />
            {/*errors.password && <p class="ErrorParagraph">{errors.password}</p>*/}
            </div>

            <div className="input-box">
                <input type="submit" />
            </div>
            
        </form>
        {/*success && <p class="SuccessParagraph">Student {user.firstname} successfully added.</p>*/}
    </div>
    </>
    );
}
 
export default Registration;