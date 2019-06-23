import React from 'react';
import IFrame from './IFrame';
import CurrentPressure from './CurrentPressure';

class Pressure extends React.Component {
    render() {
        return (
            <div>
                <CurrentPressure />
                <h2>Pressure charts</h2>
                <IFrame src={'https://api.thingspeak.com/channels/693482/charts/2?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/693482/charts/2?title=Senaste+dygnet&width=auto&height=400&days=1&average=20&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/693482/charts/2?title=Senaste+veckan&width=auto&height=400&days=7&average=60&dynamic=true'}/>
            </div>
        );
    }
}

export default Pressure;
