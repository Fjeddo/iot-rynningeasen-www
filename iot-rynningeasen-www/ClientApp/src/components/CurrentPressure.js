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
        return (
            <div>
                <h2>Current pressure</h2>
                <h3>{this.state.currentPressure}</h3>
            </div>
        );
    }
}

export default CurrentPressure;