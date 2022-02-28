import { React, useState, useRef, Form } from "react";
import axios from "axios";

// accept firstname, lastname, username, password
const Signup = () => {
  const PASS_LENGTH = 8;
  // UPDATE TO USE useRef() hook!
  // const [firstName, setFirstName] = useState("");
  // const [lastName, setLastName] = useState("");
  // const [username, setUsername] = useState("");
  // const [password, setPassword] = useState("");
  // const [passwordMatch, setPasswordMatch] = useState("");

  const firstName = useRef("");
  const lastName = useRef("");
  const username = useRef("");
  const password = useRef("");
  const passwordMatch = useRef("");

  const signupData = {
    firstName: firstName,
    lastName: lastName,
    username: username,
    password: password, // bcrypt password in backend before INSERT
  };

  // makes POST request to /login endpoint
  const handleRegister = async (e) => {
    e.preventDefault();

    if (password < PASS_LENGTH) {
      alert(`password must be greater than ${PASS_LENGTH}`);
      password.focus();
    }

    // passwords must match
    if (password !== passwordMatch) {
      alert("passwords must match!");
      passwordMatch.focus();
      // TODO: put focus back on the second password input
    }

    // post data to /signup
    await axios.post("api/signup", signupData);

    // TODO: close modal after signing up. This should just return user to the /login screen they were already on!
  };

  // TODO: render this HTML in side of the modal
  return (
    <Form type="submit">
      <label htmlfFor="firstName">First Name:</label>
      <input
        type="text"
        id="firstName"
        // value={firstName}
        ref={firstName}
        // onChange={(e) => setFirstName(e.target.value)}
      />

      <label htmlfFor="lastName">Last Name:</label>
      <input
        type="text"
        id="lastName"
        // value={lastName}
        ref={lastName}
        // onChange={(e) => setLastName(e.target.value)}
      />

      <label htmlfFor="userName">Username:</label>
      <input
        type="text"
        id="userName"
        // value={username}
        ref={username}
        // onChange={(e) => setUsername(e.target.value)}
      />

      <label htmlfFor="password">Password:</label>
      <input
        type="password"
        id="password"
        // value={password}
        ref={password}
        // onChange={(e) => setPassword(e.target.value)}
      />

      <label htmlfFor="password-match">Re-enter Password:</label>
      <input
        type="password"
        id="password-match"
        // value={passwordMatch}
        ref={passwordMatch}
        // onChange={(e) => setPasswordMatch(e.target.value)}
      />

      <button
        type="submit"
        onClick={(e) => handleRegister(e)}
        disabled={password != passwordMatch}
      >
        Register
      </button>
    </Form>
  );
};

export default Signup;
