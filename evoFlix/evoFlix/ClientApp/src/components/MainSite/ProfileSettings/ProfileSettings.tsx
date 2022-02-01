import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import "./ProfileSettings.css";

const ProfileSettings = () => {
    const [user, setUser] = useState({ username: "", email: "" });
    let history = useHistory();

    useEffect(() => {
        fetch("./users/user")
        .then(function(response){
            if(response.status == 401){
                history.push("/");
            }
            else{
                return response.json();
            }})
            .then(data => setUser(data));
    });

    function logout() {
        fetch("./users/logout", {method: 'POST'})
        .finally(() => {
            setUser({ username: "", email: ""});
            history.push("/");
        });
    }

    return (
        <>
            <div id="profile-information">
                <img alt="An image supposed to be here..." />
                <h2>{user.username}</h2>
                <h2>{user.email}</h2>
            </div>
            <div id="profile-commands">
                <h1>Change Password</h1>
                <h1>Delete profile</h1>
                <button onClick={logout}>logout</button>
            </div>
        </>     
    );
}

export default ProfileSettings;
