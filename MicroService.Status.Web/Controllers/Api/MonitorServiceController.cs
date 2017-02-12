using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using MicroService.Status.Webjob.Common.Infrastructure;

namespace MicroService.Status.Web.Controllers.Api
{
    public class MonitorServiceController : ApiController
    {
        private IServiceRepository _serviceRepository;
        public MonitorServiceController()
        {
            _serviceRepository = new ServiceRepository();
        }

        [HttpPost]
        [Route("api/monitor/register", Name = "Register service")]
        public HttpResponseMessage Register(ObservableService service)
        {
            //add service to db
            _serviceRepository.AddService(service);

            return Request.CreateResponse(HttpStatusCode.OK, "Service has been added");
        }

        [HttpPost]
        [Route("api/monitor/detach", Name = "Detach service")]
        public HttpResponseMessage Detach(IObservableService service)
        {
            //remove service from db
            _serviceRepository.RemoveService(service);
            
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        [HttpGet]
        [Route("api/monitor/status", Name = "Get status of a specific service")]
        public HttpResponseMessage GetStatus(string serviceName)
        {
            var registeredServices = _serviceRepository.GetServices();
            //get status of last run of service-checks
            return Request.CreateResponse(HttpStatusCode.OK, registeredServices);
        }
    }
}
