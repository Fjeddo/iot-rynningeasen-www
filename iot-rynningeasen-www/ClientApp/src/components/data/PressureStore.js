import { EventEmitter } from 'events';

class PressureStore extends EventEmitter {
    constructor() {
        super();
        this.currentPressure = "Getting latest pressure measurement";
    }

    getCurrentPressure() {
        return this.currentPressure;
    }
}

const pressureStore = new PressureStore();

export default pressureStore;