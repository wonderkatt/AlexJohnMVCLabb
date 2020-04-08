import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello, coaches!</h1>
        <p>Welcome to the BloodBowl Manager!</p>
      </div>
    );
  }
}
