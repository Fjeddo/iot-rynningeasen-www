import React from 'react';
import PressureStore from '../data/PressureStore';

class CurrentPressure extends React.Component {
    constructor() {
        super();

        this.getCurrentPressure = this.getCurrentPressure.bind(this);

        this.state = {
            currentPressure : PressureStore.getCurrentPressure()
        };
    }

    componentDidMount() {
        PressureStore.on("change", this.getCurrentPressure);
    }

    componentWillUnmount() {
        PressureStore.removeListener("change", this.getCurrentPressure);
    }

    getCurrentPressure() {
        this.setState({
            currentPressure : PressureStore.getCurrentPressure()
        });
    }

    render() {
        var greenText = { color: 'green' };

        return (
            <div>
                <h3>Current pressure</h3>
                <h2 style={greenText}>{this.state.currentPressure} hPa</h2>
            </div>
        );
    }
}

export default CurrentPressure;