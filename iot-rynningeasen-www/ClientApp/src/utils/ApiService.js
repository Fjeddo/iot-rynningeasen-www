import ActionCreator from '../data/ActionCreator';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';

class ApiService {
    constructor() {
        // set up signlaR etc...

        hubConnection.start().then(() => console.log('HubConnection started'));
        hubConnection.on('newpressure', (receivedMessage) => {
            console.log('Received ' + JSON.stringify(receivedMessage));
            this.receivePressureUpdates(receivedMessage);
        });

        /*setInterval(() => {
            this.receiveServerUpdates(Date.now());
        }, 2000);*/
    }

    receiveServerUpdates(data) {
        ActionCreator.updateCurrentTemperature(data);
        ActionCreator.updateCurrentPressure(data + Date.now());
    }

    receivePressureUpdates(data) {
        ActionCreator.updateCurrentPressure(data);
    }

};

const hubConnection = new HubConnectionBuilder()
    .withUrl("/serverpush")
    .configureLogging(LogLevel.Information)
    .build();

new ApiService();