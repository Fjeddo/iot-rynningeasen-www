import { EventEmitter } from 'events';

class PressureStore extends EventEmitter {
    constructor() {
        super();
        this.currentPressure = "Getting latest pressure measurement";
    }
}

const pressureStore = new PressureStore();

export default pressureStore;