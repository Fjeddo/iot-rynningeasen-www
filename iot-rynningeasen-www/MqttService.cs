using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace iot_rynningeasen_www
{
    public class MqttService : IHostedService
    {
        private readonly IHubContext<MeasurementsHub> _hub;
        private readonly MqttClient _mqttClient;
        private readonly IConfiguration _configuration;
        private string _channelsSubscriptionPressure;
        private string _channelsSubscriptionTemp;

        public static string Pressure { get; private set; }
        public static string Temperature { get; private set; }

        public MqttService(IHubContext<MeasurementsHub> hub, MqttClient mqttClient, IConfiguration configuration)
        {
            _mqttClient = mqttClient;
            _configuration = configuration;
            _hub = hub;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _mqttClient.MqttMsgPublishReceived += _mqttClient_MqttMsgPublishReceived;

            _mqttClient.Connect(
                Guid.NewGuid().ToString(),
                _configuration["thingspeak-mqtt-user"],
                _configuration["thingspeak-mqtt-password"]);

            _channelsSubscriptionPressure = _configuration["Mqtt:PressureTopic"];
            _channelsSubscriptionTemp = _configuration["Mqtt:TemperatureTopic"];

            _mqttClient.Subscribe(
                new[] {_channelsSubscriptionPressure, _channelsSubscriptionTemp},
                new[] {MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE});

            return Task.CompletedTask;
        }

        private void _mqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var data = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine($"Received {data}");

            string method;

            if (e.Topic == _configuration["Mqtt:PressureTopic"])
            {
                method = "newpressure";
                Pressure = data.Trim();
            }
            else if(e.Topic == _configuration["Mqtt:TemperatureTopic"])
                {
                    method = "newtemperature";
                    Temperature = data.Trim();
                }
            else
            {
                throw new UnknownTopicException(e.Topic);
            }
            
            _hub.Clients.All.SendAsync(method, data);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _mqttClient?.Unsubscribe(new[] {_channelsSubscriptionPressure, _channelsSubscriptionTemp});
            if (_mqttClient != null && _mqttClient.IsConnected)
            {
                _mqttClient.Disconnect();
            }

            return Task.CompletedTask;
        }
    }
}
