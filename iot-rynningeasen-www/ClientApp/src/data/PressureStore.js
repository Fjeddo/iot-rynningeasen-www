import { EventEmitter } from 'events';
import dispatcher from './Dispatcher'
import { ACTION_TYPES } from './ActionTypes';

class PressureStore extends EventEmitter {
    constructor() {
        super();
        this.currentPressure = "Getting latest pressure measurement";
    }

    getCurrentPressure() {
        return this.currentPressure;
    }

    handleActions(action) {
        switch(action.type) {
            case ACTION_TYPES.UPDATE_CURRENT_PRESSURE: {
                this.currentPressure = action.data;
                this.emit("change");
                break;
            }
            default: break;
        }
    }
}

const pressureStore = new PressureStore();
dispatcher.register(pressureStore.handleActions.bind(pressureStore));

export default pressureStore;