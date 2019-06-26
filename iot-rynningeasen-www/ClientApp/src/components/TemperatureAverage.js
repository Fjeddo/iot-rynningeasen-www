import React from 'react';
import AverageStore from '../data/AverageStore';

class TemperatureAverage extends React.Component {
    constructor() {
        super();

        this.getTemperatureAverage = this.getTemperatureAverage.bind(this);

        this.state = {
            temperatureAverage : AverageStore.getTemperatureAverage()
        };
    }

    componentDidMount() {
        AverageStore.on("change", this.getTemperatureAverage);
    }

    componentWillUnmount() {
        AverageStore.removeListener("change", this.getTemperatureAverage);
    }

    getTemperatureAverage() {
        this.setState({
            temperatureAverage : AverageStore.getTemperatureAverage()
        });
    }

    render() {
        var greenSmallText = { color: 'green', fontSize: '90%' };
        var smallHeader = { fontSize: '70%' };

        return (
            <div>
                <h3 style={smallHeader}>Average temperature last week</h3>
                <h2 style={greenSmallText}>{this.state.temperatureAverage}<sup>o</sup>C</h2>
            </div>
        );
    }
}

export default TemperatureAverage;