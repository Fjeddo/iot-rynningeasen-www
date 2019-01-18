import React from 'react';
import TemperatureStore from './data/TemperatureStore';

class CurrentTemperature extends React.Component {
    constructor() {
        super();
        this.state = {
            currentTemperature : TemperatureStore.getCurrentTemperature()
        };
    }

    render() {
        return (
            <div>
                <h2>Current temperature</h2>
                <h3>{this.state.currentTemperature}</h3>
            </div>
        );
    }
}

export default CurrentTemperature;