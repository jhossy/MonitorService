using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.Status.Webjob.Common.Infrastructure;

namespace MicroService.Status.Webjob.Monitor.Infrastructure
{
    public interface IStatusHandler
    {
        Task<string> GetStatus();
    }
}
