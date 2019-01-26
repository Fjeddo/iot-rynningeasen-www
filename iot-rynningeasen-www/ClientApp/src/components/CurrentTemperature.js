import React from 'react';
import TemperatureStore from '../data/TemperatureStore';

class CurrentTemperature extends React.Component {
    constructor() {
        super();

        this.getCurrentTemperature = this.getCurrentTemperature.bind(this);

        this.state = {
            currentTemperature : TemperatureStore.getCurrentTemperature()
        };
    }

    componentDidMount() {
        TemperatureStore.on("change", this.getCurrentTemperature);
    }

    componentWillUnmount() {
        TemperatureStore.removeListener("change", this.getCurrentTemperature);
    }

    getCurrentTemperature() {
        this.setState({
            currentTemperature : TemperatureStore.getCurrentTemperature()
        });
    }

    render() {
        var greenText = { color: 'green' };

        return (
            <div>
                <h3>Current temperature</h3>
                <h2 style={greenText}>{this.state.currentTemperature}</h2>
            </div>
        );
    }
}

export default CurrentTemperature;