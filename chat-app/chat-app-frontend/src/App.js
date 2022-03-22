import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import Signup from "./components/Signup";
import Login from "./components/Login";
import Main from "./components/pages/Main";

function App() {
  return (
    <Router>
      <div className="App">
        <div>
          <Routes>
            <Route exact path="/login" element={<Login />} />
            <Route exact path="/signup" element={<Signup />} />
            <Route exact path="/chat" element={<Main />} />
            {/* <Route exact path="*" element={<ErrorPage />} /> */}
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
    </Router>
  );
}

export default App;
