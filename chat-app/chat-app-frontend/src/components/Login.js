import { React, useState, useRef, Form } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
// import { BrowserRouter as Router, Routes, Routem useHistory } from "react-router-dom";

const Login = () => {
  // UPDATE TO USE useRef() hook!
  // const [username, setUsername] = useState("");
  // const [password, setPassword] = useState("");

  const username = useRef("");
  const password = useRef("");
  // initiate useHistory() hook here

  const loginData = {
    username: username,
    password: password,
  };

  // send username & password to /login
  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      await axios
        .post("/login", loginData)
        .then((res) => {
          // TODO: save jwt_token here to session storage for accessing other endpoints
        })
        .catch((err) => {
          console.log(err.Message);
        });
    } catch (err) {
      console.log(err.Message);
    }

    //TODO: redirect user to /chatroom endpoint here after login using history
  };

  return (
    <>
      <Form type="submit">
        <label htmlfFor="userName">Username:</label>
        <input
          type="text"
          id="userName"
          ref={username}
          // value={username}
          // onChange={(e) => setUsername(e.target.value)}
        />

        <label htmlfFor="password">Password:</label>
        <input
          type="password"
          id="password"
          ref={password}
          // value={password}
          // onChange={(e) => setPassword(e.target.value)}
        />
        <button type="submit" onClick={(e) => handleLogin(e)}>
          Login
        </button>
      </Form>
      {/* make this have a pop-up modal for signing up */}
      <h3>
        Don't have an acount? <Link href="/signup">Signup</Link>
      </h3>
    </>
  );
};

export default Login;
