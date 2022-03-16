import { BrowserRouter, Routes, Route } from "react-router-dom";
import React from "react";
import "./App.css";
import Signup from "./components/Signup";
import Login from "./components/Login";
import Home from "./components/pages/Home";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <div>
          <Routes>
            <Route exact path="/login" element={<Login />} />
            <Route exact path="/signup" element={<Signup />} />
            <Route exact path="/" element={<Home />} />
          </Routes>
        </div>
      </div>

      {/* <h1 className="text-3xl font-bold underline">Hello World!</h1>
      <div className="d-flex border-solid border-4 border-sky-500">
        <p className=""> tailwindcss</p>
        <button className="border-solid border-4 bg-slate-300 rounded border-sky-500 hover:border-dotted">
          button
        </button>
        <div>
          <ul>
            <li>1</li>
            <li>2</li>
            <li>3</li>
            <li>4</li>
          </ul>
        </div>
      </div> */}
    </BrowserRouter>
  );
}

export default App;
