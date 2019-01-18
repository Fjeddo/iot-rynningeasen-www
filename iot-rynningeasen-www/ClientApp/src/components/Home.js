import React, { Component } from 'react';
import CurrentTemperature from './CurrentTemperature';
import CurrentPressure from './CurrentPressure';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Current measurements @ Rynningeåsen</h1>
        <CurrentTemperature />
        <CurrentPressure />
      </div>
    );
  }
}
