import React, { useEffect, useState } from "react";
 
const Registration = () => {
 
    const [user, setUser] = useState({
        firstname: '',
        lastname: '',
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
        
 
        <div className="DivCard centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
            <form id="registrationForm">
                {/* register your input into the hook by invoking the "register" function */}
                Firstname:
                <input type="text" name="firstname" value={user.firstname} placeholder="Joseph" onChange={handleChange} />
 
                {/*errors.firstname && <p class="ErrorParagraph">{errors.firstname}</p>*/}
                Lastname:
                <input type="text" name="lastname" value={user.lastname} placeholder="Smith" onChange={handleChange} />
                {/*errors.lastname && <p class="ErrorParagraph">{errors.lastname}</p>*/}
 
                Email:
                <input type="text" name="email" value={user.email} placeholder="example@mail.com" onChange={handleChange} />
                {/*errors.email && <p class="ErrorParagraph">{errors.email}</p>*/}
                {/*emailExists && <p class="ErrorParagraph">Email already exist</p>*/}
 
                Password:
                <input type="password" name="password" value={user.password} placeholder="••••••••" onChange={handleChange} />
                {/*errors.password && <p class="ErrorParagraph">{errors.password}</p>*/}
 
                Confirm password:
                <input type="password" name="password2" value={user.password2} placeholder="••••••••" onChange={handleChange} />
                {/*errors.password2 && <p class="ErrorParagraph">{errors.password2}</p>*/}
 
                <input type="submit" />
            </form>
            {/*success && <p class="SuccessParagraph">Student {user.firstname} successfully added.</p>*/}
        </div>
    );
}
 
export default Registration;