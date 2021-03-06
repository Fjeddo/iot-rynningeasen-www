import React, { Component } from 'react';
import CurrentTemperature from './CurrentTemperature';
import TemperatureAverage from './TemperatureAverage';
import CurrentPressure from './CurrentPressure';
import CurrentHumidity from './CurrentHumidity';
import IFrame from './IFrame';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Current measurements @ Rynningeåsen</h1>
	    <div style={{float:"left"}}><CurrentTemperature /></div>
		<div style={{float:"right"}}><TemperatureAverage /></div>
	    <IFrame src={'https://api.thingspeak.com/channels/693480/charts/1?title=Senaste+dygnet&width=auto&height=400&days=1&average=15&dynamic=true'} />
	    <CurrentPressure />
        <IFrame src={'https://api.thingspeak.com/channels/693482/charts/2?title=Senaste+dygnet&width=auto&height=400&days=1&average=15&dynamic=true'} />
        <CurrentHumidity />
        <IFrame src={'https://api.thingspeak.com/channels/796905/charts/3?title=Senaste+dygnet&width=auto&height=400&days=1&average=15&dynamic=true'} />
      </div>
    );
  }
}
