import React, { useEffect, useState } from "react";
import "./ProfileSettings.css";

const ProfileSettings = () => {
    const [user, setUser] = useState({ username: "lajos", email: "lajos@gmail.com" });

    useEffect(() => {
        fetch("./users/user")
            .then(res => res.json())
            .then(data => setUser(data));
    }, []);

    return (
        <>
            <div id="profile-information">
                <img alt="An image supposed to be here..." />
                <a>{"\n"}Change profile picture</a>
                <h2>{user.username}</h2>
                <h2>{user.email}</h2>
            </div>
            <div id="profile-commands">
                <h1>Change Password</h1>
                <h1>Delete profile</h1>
            </div>
        </>     
    );
}

export default ProfileSettings;
