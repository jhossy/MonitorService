using System.Collections.Generic;

namespace MicroService.Status.Webjob.Common.Infrastructure
{
    public interface IServiceRepository
    {
        List<IObservableService> GetServices();

        void AddService(IObservableService service);

        void RemoveService(IObservableService service);
    }
}
