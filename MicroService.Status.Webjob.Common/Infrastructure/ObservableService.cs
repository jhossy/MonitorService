using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Status.Webjob.Common.Infrastructure
{
    public class ObservableService : IObservableService
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ServiceType { get; set; }
        public int ExecuteIntervalInMs { get; set; }
    }
}
