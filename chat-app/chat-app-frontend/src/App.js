import "./App.css";

function App() {
  return (
    <div className="App">
      <h1 className="text-3xl font-bold underline">Hello World!</h1>
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
      </div>
    </div>
  );
}

export default App;
