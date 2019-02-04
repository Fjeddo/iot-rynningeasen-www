import React, { Component } from 'react';
import CurrentTemperature from './CurrentTemperature';
import CurrentPressure from './CurrentPressure';
import IFrame from './IFrame';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Current measurements @ Rynningeåsen</h1>
        <CurrentTemperature />
        <IFrame src={'https://api.thingspeak.com/channels/693480/charts/1?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
        <CurrentPressure />
        <IFrame src={'https://api.thingspeak.com/channels/693482/charts/2?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
      
      </div>
    );
  }
}
