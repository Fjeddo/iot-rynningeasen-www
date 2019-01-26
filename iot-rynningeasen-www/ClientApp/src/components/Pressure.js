import React from 'react';
import IFrame from './IFrame';

class Pressure extends React.Component {
    render() {
        return (
            <div>
                <h2>Pressure charts</h2>
                <IFrame src={'https://api.thingspeak.com/channels/661241/charts/1?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/661241/charts/1?title=Senaste+dygnet&width=auto&height=400&results=1440&dynamic=true&average=30'}/>
                <IFrame src={'https://api.thingspeak.com/channels/661241/charts/1?title=Senaste+veckan&width=auto&height=400&results=10080&dynamic=true&average=240'}/>
            </div>
        );
    }
}

export default Pressure;