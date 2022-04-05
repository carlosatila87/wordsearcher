import React, { Component } from "react";
import WordService from "../services/word.service";
export default class AddWord extends Component {
  constructor(props) {
    super(props);
    this.onChangeWord = this.onChangeWord.bind(this);
    this.saveWord = this.saveWord.bind(this);
    this.newWord = this.newWord.bind(this);
    this.state = {
      word: "",
      submitted: false
    };
  }
  onChangeWord(e) {
    this.setState({
      word: e.target.value
    });
  }
  saveWord() {
    WordService.addWord(this.state.word)
    .then(() => {
        this.setState({
          submitted: true
        });
    })
      .catch(e => {
        console.log(e);
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
            <h4>Word added successfully!</h4>
            <button className="btn btn-success" onClick={this.newWord}>
              Add New
            </button>
          </div>
        ) : (
          <div>
            <div className="form-group">
              <label htmlFor="title">Add Word</label>
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
            <button onClick={this.saveWord} className="btn btn-success">
              Save
            </button>
          </div>
        )}
      </div>
    );
  }
}