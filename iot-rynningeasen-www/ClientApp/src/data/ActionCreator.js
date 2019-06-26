import Dispatcher from './Dispatcher';
import { ACTION_TYPES } from './ActionTypes';

class ActionCreator {
    updateCurrentTemperature(temperature) {
        var action = { type : ACTION_TYPES.UPDATE_CURRENT_TEMPERATURE, data : temperature };
        Dispatcher.dispatch(action);

        console.log("Created action: " + JSON.stringify(action));
    }

    updateCurrentPressure(pressure) {
        var action = { type : ACTION_TYPES.UPDATE_CURRENT_PRESSURE, data : pressure };
        Dispatcher.dispatch(action);

        console.log("Created action: " + JSON.stringify(action));
    }

    updateCurrentHumidity(humidity) {
        var action = { type : ACTION_TYPES.UPDATE_CURRENT_HUMIDITY, data : humidity };
        Dispatcher.dispatch(action);

        console.log("Created action: " + JSON.stringify(action));
    }

    updateAverage(average) {
        var action = { type : ACTION_TYPES.UPDATE_AVERAGE, data : average };
        Dispatcher.dispatch(action);

        console.log("Created action: " + JSON.stringify(action));
    }
}

const actionCreator = new ActionCreator();

export default actionCreator;