import React from 'react';
import IFrame from './IFrame';
import CurrentHumidity from './CurrentHumidity';

class Humidity extends React.Component {
    render() {
        return (
            <div>
                <CurrentHumidity />
                <h2>Humidity charts</h2>
                <IFrame src={'https://api.thingspeak.com/channels/796905/charts/3?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/796905/charts/3?title=Senaste+dygnet&width=auto&height=400&days=1&average=20&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/796905/charts/3?title=Senaste+veckan&width=auto&height=400&days=7&average=60&dynamic=true'}/>
            </div>
        );
    }
}

export default Humidity;
