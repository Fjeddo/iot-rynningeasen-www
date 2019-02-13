import React from 'react';
import IFrame from './IFrame';

class Temperature extends React.Component {
    render() {    

        return (
            <div>
                <h2>Temperature charts</h2>
                <IFrame src={'https://api.thingspeak.com/channels/693480/charts/1?title=Senaste+timmen&width=auto&height=400&results=60&dynamic=true'}/>
                <IFrame src={'https://api.thingspeak.com/channels/693480/charts/1?title=Senaste+dygnet&width=auto&height=400&days=1&average=20'}/>
                <IFrame src={'https://api.thingspeak.com/channels/693480/charts/1?title=Senaste+veckan&width=auto&height=400&days=7&average=240'}/>
            </div>
        );
    }
}

export default Temperature;
