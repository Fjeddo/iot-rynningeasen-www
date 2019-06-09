import ActionCreator from '../data/ActionCreator';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';

class ApiService {
    constructor() {
        hubConnection.start().then(() => console.log('HubConnection started'));

        hubConnection.on('newpressure', (receivedMessage) => {
            console.log('Received ' + JSON.stringify(receivedMessage));
            this.receivePressureUpdates(receivedMessage);
        });
        
        hubConnection.on('newtemperature', (receivedMessage) => {
            console.log('Received ' + JSON.stringify(receivedMessage));
            this.receiveTemperatureUpdates(receivedMessage);
        });

        hubConnection.on('newhumidity', (receivedMessage) => {
            console.log('Received ' + JSON.stringify(receivedMessage));
            this.receiveHumidityUpdates(receivedMessage);
        });
    }

    receiveTemperatureUpdates(data) {
        ActionCreator.updateCurrentTemperature(data);
    }

    receivePressureUpdates(data) {
        ActionCreator.updateCurrentPressure(data);
    }

    receiveHumidityUpdates(data) {
        ActionCreator.updateCurrentHumidity(data);
    }

};

const hubConnection = new HubConnectionBuilder()
    .withUrl("/serverpush")
    .configureLogging(LogLevel.Information)
    .build();

new ApiService();
