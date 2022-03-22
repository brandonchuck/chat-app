import axios from "axios";
import React from "react";
import { useForm } from "react-hook-form";

// accept firstname, lastname, username, password
const Signup = () => {
  const PASS_LENGTH = 8;

  const { register, handleSubmit } = useForm();

  const onSubmit = async (signupData) => {
    // signupData is the data extracted from each form input

    // Validate password length
    if (signupData.password.length < PASS_LENGTH) {
      alert(`password must be greater than ${PASS_LENGTH} characters`);
    }

    // Confirm password
    if (signupData.password !== signupData.passwordMatch) {
      alert("passwords must match!");
      // TODO: put focus back on the second password input
    }

    // send user info to /singup
    await axios
      .post("api/auth/signup", signupData)
      .then((res) => console.log(res.data)); // this should print "Registration successful!"

    console.log(signupData);
    // console.dir(onSubmit);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <label htmlFor="firstName">First Name:</label>
      <input
        type="text"
        name="firstName"
        placeholder="First Name"
        {...register("firstName", { required: true })}
      />

      <label htmlFor="lastName">Last Name:</label>
      <input
        type="text"
        name="lastName"
        placeholder="Last Name"
        {...register("lastName", { required: true })}
      />

      <label htmlFor="userName">Username:</label>
      <input
        type="text"
        name="username"
        placeholder="Username"
        {...register("username", { required: true })}
      />

      <label htmlFor="password">Password:</label>
      <input
        type="password"
        name="password"
        placeholder="Password"
        {...register("password", { required: true })}
      />

      <label htmlFor="password-match">Confirm Password:</label>
      <input
        type="password"
        name="passwordMatch"
        placeholder="Confirm Password"
        {...register("passwordMatch", { required: true })}
      />

      <button type="submit">Register</button>

      <h3>
        Already have an accoutn? <a href="/login">Login</a>
      </h3>
    </form>
  );
};

export default Signup;
