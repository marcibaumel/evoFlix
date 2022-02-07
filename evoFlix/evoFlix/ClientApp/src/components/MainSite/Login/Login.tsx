import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { useHistory } from "react-router-dom";
import "./Login.css";
import "bootstrap/dist/css/bootstrap.min.css";
interface Props {
  loginFunction: (value: boolean) => void;
}

const Login = ({ loginFunction }: Props) => {
  let history = useHistory();

  const [user, setUser] = useState({
    username: "",
    password: "",
  });

  const [success, setSuccess] = useState(false);

  const handleChange = (e: { target: { name: any; value: any } }) => {
    setUser({
      ...user,
      [e.target.name]: e.target.value,
    });
  };

  const handleLogin = () => {
    console.log(user.username, user.password);

    fetch("./Users/login", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        username: user.username,
        password: user.password,
      }),
    }).then(function (response) {
      if (response.status == 200 || response.status == 201) {
        loginFunction(true);
        setSuccess(true);
        history.push("/watchsomething");
      } else {
        setSuccess(false);
        alert("Something not seems to be okay with your login data");
      }
    });

    user.username = "";
    user.password = "";
  };

  function checkPasswordFormat(password: string): boolean {
    //at least a symbol, upper and lower case letters and a number + min 6 letter
    const regex = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{6,}$/;
    if (password.length > 0) {
      if (regex.test(password)) {
        return true;
      }
      return false;
    }
    return true;
  }

  return (
    <>
      <div>
        <Form>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Label>Enter your username</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter your username"
              name="username"
              value={user.username}
              onChange={handleChange}
            />
            <Form.Text className="text-muted">
              Please enter your username
            </Form.Text>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Label>Password</Form.Label>
            <Form.Control
              type="password"
              placeholder="Password"
              name="password"
              value={user.password}
              onChange={handleChange}
            />
          </Form.Group>
          <Button variant="primary" size="lg" onClick={handleLogin} value="Login">
            Login
          </Button>{" "}
        </Form>
      </div>
    </>
  );
};

export default Login;
