using System;
using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace MicroService.Status.Webjob.Common.Infrastructure
{
    public class ServiceRepository : IServiceRepository
    {
        private IDocumentStore _store;
        public ServiceRepository()
        {
            _store = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "services"
            }.Initialize();
        }

        public List<IObservableService> GetServices()
        {
            List<IObservableService> _servicesInDb = new List<IObservableService>();
            using (IDocumentSession session = _store.OpenSession())
            {
                _servicesInDb.AddRange(session.Query<ObservableService>().Take(100).ToList());
            }
            return _servicesInDb;
        }

        public void AddService(IObservableService service)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                session.Store(service);
                session.SaveChanges();
            }
        }

        public void RemoveService(IObservableService service)
        {
            throw new NotImplementedException();
        }
    }
}
