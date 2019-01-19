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
        return (
            <div>
                <h2>Current temperature</h2>
                <h3>{this.state.currentTemperature}</h3>
            </div>
        );
    }
}

export default CurrentTemperature;