using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using MicroService.Status.Webjob.Common.Infrastructure;
using MicroService.Status.Webjob.Monitor.Infrastructure;

namespace MicroService.Status.Webjob.Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += (sender, eventArgs) =>
            {
                IServiceRepository serviceRepository = new ServiceRepository();
                List<IObservableService> servicesFromDb = serviceRepository.GetServices();

                //create statushandler for each elm in db
                foreach (var service in servicesFromDb)
                {
                    IStatusHandler handler = new StatusHandler(service);

                    //run getstatus as individual tasks
                    Task.Factory.StartNew(async () =>
                    {
                        //return status to console
                        Console.WriteLine(DateTime.Now.ToLongTimeString() + " - Status from " + service.Url + ": " +
                                          await handler.GetStatus());
                    });
                }
            };

            timer.Start();

            Console.ReadLine();
        }
    }
}
