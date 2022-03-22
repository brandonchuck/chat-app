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
    </Router>
  );
}

export default App;
