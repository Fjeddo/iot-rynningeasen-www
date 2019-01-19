import { EventEmitter } from 'events';
import dispatcher from './Dispatcher'
import { ACTION_TYPES } from './ActionTypes';

class TemperatureStore extends EventEmitter {
    constructor() {
        super();
        this.currentTemperature = "Getting latest temperature measurement";
    }

    getCurrentTemperature() {
        return this.currentTemperature;
    }

    handleActions(action) {
        switch(action.type) {
            case ACTION_TYPES.UPDATE_CURRENT_TEMPERATURE: {
                this.currentTemperature = action.data;
                this.emit("change");
                break;
            }
            default: break;
        }
    }
}

const temperatureStore = new TemperatureStore();
dispatcher.register(temperatureStore.handleActions.bind(temperatureStore));

export default temperatureStore;