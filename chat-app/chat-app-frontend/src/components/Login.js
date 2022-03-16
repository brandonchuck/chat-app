import React from "react";
import axios from "axios";
import { useForm } from "react-hook-form";

const Login = () => {
  const { register, handleSubmit, reset } = useForm();

  const onSubmit = async (loginData) => {
    await axios.post("api/auth/login", loginData).then((res) => {
      localStorage.setItem("token", res.data.token); // store jwt in localStorage
    });

    console.dir(onSubmit);
  };

  //TODO: redirect user to /chatroom endpoint here after login using history

  return (
    <div>
      <form type="submit" onSubmit={handleSubmit(onSubmit)}>
        <label htmlFor="username">Username:</label>
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
        <button type="submit" onClick={() => reset()}>
          Login
        </button>
      </form>

      <h3>
        Don't have an acount? <a href="/signup">Signup</a>
      </h3>
    </div>
  );
};

export default Login;
