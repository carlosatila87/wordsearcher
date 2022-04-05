import React, { Component } from "react";
import WordService from "../services/word.service";
export default class SearchWord extends Component {
  constructor(props) {
    super(props);
    this.onChangeWord = this.onChangeWord.bind(this);
    this.searchWord = this.searchWord.bind(this);
    this.newWord = this.newWord.bind(this);
    this.state = {
      word: "",
      submitted: false,
      exists: false,
    };
  }
  onChangeWord(e) {
    this.setState({
      word: e.target.value
    });
  }
  searchWord() {
    WordService.search(this.state.word)
    .then(() => {
      this.setState({
        submitted: true,
        exists: true
      });
    })
    .catch(e => {
      const error = e.response;
      if (error.status === 404) {
        this.setState({
          submitted: true,
          exists: false
        });
      }
      else {
        console.log(error.statusText);
      }
    });
  }
  newWord() {
    this.setState({
      word: "",
      submitted: false
    });
  }
  render() {
    return (
      <div className="submit-form">
        {this.state.submitted ? (
          <div>
            <h4>{this.state.exists ? 'This word is in the database' : 'This word is not in the database'}</h4>
            <button className="btn btn-success" onClick={this.newWord}>
              Search New
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="title">Search Word</label>
              <input
                type="text"
                className="form-control"
                id="word"
                required
                value={this.state.word}
                onChange={this.onChangeWord}
                name="word"
              />
            </div>
            <button onClick={this.searchWord} className="btn btn-success">
              Search
            </button>
          </div>
        )}
      </div>
    );
  }
}