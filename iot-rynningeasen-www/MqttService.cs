using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace iot_rynningeasen_www
{
    public class MqttService : IHostedService, IDisposable
    {
        private Timer _timer;
        private IHubContext<MeasurementsHub> _hub;

        public MqttService(IHubContext<MeasurementsHub> hub)
        {
            _hub = hub;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(
                async state => { await _hub.Clients.All.SendAsync("newpressure", DateTimeOffset.Now.Ticks); },
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
