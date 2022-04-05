import React, { Component } from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import AddWord from "./components/add-word.component";
import SearchWord from "./components/search-word.component";
import Top5Words from "./components/top5-words.component";
class App extends Component {
  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <a href="/search-word" className="navbar-brand">
            WordService
          </a>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/search-word"} className="nav-link">
                Search Word
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/add-word"} className="nav-link">
                Add Word
              </Link>
            </li>
            <li className="nav-item">
              <Link to={"/top5-words"} className="nav-link">
                Top 5 Words
              </Link>
            </li>
          </div>
        </nav>
        <div className="container mt-3">
          <Routes>
            <Route exact path="/search-word" element={<SearchWord/>} />
            <Route exact path="/add-word" element={<AddWord/>} />
            <Route exact path="/top5-words" element={<Top5Words/>} />
          </Routes>
        </div>
      </div>
    );
  }
}
export default App;