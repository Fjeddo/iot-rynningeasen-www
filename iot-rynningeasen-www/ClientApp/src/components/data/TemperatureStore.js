import { EventEmitter } from 'events';

class TemperatureStore extends EventEmitter {
    constructor() {
        super();
        this.currentTemperature = "Getting latest temperature measurement";
    }
}

const temperatureStore = new TemperatureStore();

export default temperatureStore;