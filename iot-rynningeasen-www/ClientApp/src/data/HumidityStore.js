import { EventEmitter } from 'events';
import dispatcher from './Dispatcher'
import { ACTION_TYPES } from './ActionTypes';

class HumidityStore extends EventEmitter {
    constructor() {
        super();
        this.currentHumidity = "...";
    }

    getCurrentHumidity() {
        return this.currentHumidity;
    }

    handleActions(action) {
        switch(action.type) {
            case ACTION_TYPES.UPDATE_CURRENT_HUMIDITY: {
                this.currentHumidity = action.data;
                this.emit("change");
                break;
            }
            default: break;
        }
    }
}

const humidityStore = new HumidityStore();
dispatcher.register(humidityStore.handleActions.bind(humidityStore));

export default humidityStore;