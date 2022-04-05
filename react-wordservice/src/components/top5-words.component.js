
import React, { Component } from "react";
import WordService from "../services/word.service";
export default class Top5Words extends Component {
  constructor(props) {
    super(props);
    this.retrieveTop5WordsList = this.retrieveTop5WordsList.bind(this);
    this.state = {
      wordsList: [],
    };
  }
  componentDidMount() {
    this.retrieveTop5WordsList();
  }
  retrieveTop5WordsList() {
    WordService.getTop5()
      .then(response => {
        this.setState({
          wordsList: response.data
        });
    })
    .catch(e => {
        console.log(e);
    });
  }
  render() {
    const { wordsList } = this.state;
    return (
      <div className="list row">
        <div className="col-md-6">
          <h4>Top 5 Words List</h4>
          <ul className="list-group">
            {wordsList &&
              wordsList.map((word, index) => (
                <li
                  className="list-group-item"
                  key={index}
                >
                  {word.word} - {word.count}
                </li>
              ))}
          </ul>
        </div>
      </div>
    );
  }
}