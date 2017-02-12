using System;
using System.Net.Http;
using System.Threading.Tasks;
using MicroService.Status.Webjob.Common.Infrastructure;

namespace MicroService.Status.Webjob.Monitor.Infrastructure
{
    public class StatusHandler : IStatusHandler
    {
        private IObservableService _service;
        private int _serviceTimeout = 15; //move to config

        public StatusHandler(IObservableService service)
        {
            _service = service;
        }

        public async Task<string> GetStatus()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(_serviceTimeout);
            return await client.GetStringAsync(_service.Url);
        }
    }
}
