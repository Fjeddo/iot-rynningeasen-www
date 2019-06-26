import { EventEmitter } from 'events';
import dispatcher from './Dispatcher'
import { ACTION_TYPES } from './ActionTypes';

class AverageStore extends EventEmitter {
    constructor() {
        super();
        this.average = { temperature : "..." };
    }

    getTemperatureAverage() {
        return this.average.temperature;
    }

    handleActions(action) {
        switch(action.type) {
            case ACTION_TYPES.UPDATE_AVERAGE: {
                this.average = action.data;
                this.emit("change");
                break;
            }
            default: break;
        }
    }
}

const averageStore = new AverageStore();
dispatcher.register(averageStore.handleActions.bind(averageStore));

export default averageStore;