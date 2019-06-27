import React from 'react';
import AverageStore from '../data/AverageStore';

class TemperatureAverage extends React.Component {
    constructor() {
        super();

        this.getTemperatureAverage = this.getTemperatureAverage.bind(this);
        this.state = AverageStore.getTemperatureAverage();
    }

    componentDidMount() {
        AverageStore.on("change", this.getTemperatureAverage);
    }

    componentWillUnmount() {
        AverageStore.removeListener("change", this.getTemperatureAverage);
    }

    getTemperatureAverage() {
	    var avg = AverageStore.getTemperatureAverage();
	    this.setState({
		    yesterday: avg.yesterday,
		    lastWeek: avg.lastWeek
    });
    }

    render() {
        var greenSmallText = { color: 'green', fontSize: '90%' };
        var smallHeader = { fontSize: '70%' };

        return (
            <div>
                <h3 style={smallHeader}>Average yesterday</h3>
                <h2 style={greenSmallText}>{this.state.yesterday}<sup>o</sup>C</h2>
				<h3 style={smallHeader}>Average last week</h3>
				<h2 style={greenSmallText}>{this.state.lastWeek}<sup>o</sup>C</h2>
            </div>
        );
    }
}

export default TemperatureAverage;