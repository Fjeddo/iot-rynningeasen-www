import { EventEmitter } from 'events';

class TemperatureStore extends EventEmitter {
    constructor() {
        super();
        this.currentTemperature = "Getting latest temperature measurement";
    }

    getCurrentTemperature() {
        return this.currentTemperature;
    }
}

const temperatureStore = new TemperatureStore();

export default temperatureStore;