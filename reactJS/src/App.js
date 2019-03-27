import React, { Component } from 'react';
import './App.css';

import Todos from './components/Todos.js';

class App extends Component {
  render() {
    return (
      <div className="App">
        <Todos />
      </div>
    );
  }
}

export default App;
