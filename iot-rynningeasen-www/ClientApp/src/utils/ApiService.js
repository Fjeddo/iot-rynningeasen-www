import ActionCreator from '../data/ActionCreator';

class ApiService {
    constructor() {
        // set up signlaR etc...

        setInterval(() => {
            this.receiveServerUpdates(Date.now());
        }, 2000);
    }

    receiveServerUpdates(data) {
        ActionCreator.updateCurrentTemperature(data);
        ActionCreator.updateCurrentPressure(data + Date.now());
    }
}

new ApiService();