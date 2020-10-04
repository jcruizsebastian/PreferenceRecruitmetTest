import React from 'react';
import logo from './logo.svg';
import './App.css';
import  store  from './redux/index'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;


// import React from 'react';
// import './App.css';
// import  store  from './redux/index'

// function App() {
//   return (
//     <div className="App">
//       <input id="tbUserName" type="text" placeholder="type here your user name" />
//       <input id="tbPassword" type="text" placeholder="type here your password" />
//       <button 
//     </div>
//   );
// }

// export default App;
