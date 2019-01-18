import React from 'react';
import PressureStore from './data/PressureStore';

class CurrentPressure extends React.Component {
    constructor() {
        super();
        this.state = {
            currentPressure : PressureStore.getCurrentPressure()
        };
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