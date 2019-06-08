import React from 'react';
import HumidityStore from '../data/HumidityStore';

class CurrentHumidity extends React.Component {
    constructor() {
        super();

        this.getCurrentHumidity = this.getCurrentHumidity.bind(this);

        this.state = {
            currentHumidity : HumidityStore.getCurrentHumidity()
        };
    }

    componentDidMount() {
        HumidityStore.on("change", this.getCurrentHumidity);
    }

    componentWillUnmount() {
        HumidityStore.removeListener("change", this.getCurrentHumidity);
    }

    getCurrentHumidity() {
        this.setState({
            currentHumidity : HumidityStore.getCurrentHumidity()
        });
    }

    render() {
        var greenText = { color: 'green' };

        return (
            <div>
                <h3>Current humidity</h3>
                <h2 style={greenText}>{this.state.currentHumidity} hPa</h2>
            </div>
        );
    }
}

export default CurrentHumidity;