namespace MicroService.Status.Webjob.Common.Infrastructure
{
    public interface IObservableService
    {
        string Name { get; set; }

        string Url { get; set; }

        int ServiceType { get; set; }

        int ExecuteIntervalInMs { get; set; }
    }
}
