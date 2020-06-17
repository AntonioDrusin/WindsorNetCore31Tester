using Microsoft.Extensions.DependencyInjection;


namespace WebApplication3.Services
{
    public interface ITransientDependentOnPerRequestService 
    {
    }

    public class TransientDependentOnDependentOnPerRequestService : LifeTimeLogger, ITransientDependentOnPerRequestService
    {
        private readonly IPerWebRequestService _web;

        public TransientDependentOnDependentOnPerRequestService(IPerWebRequestService web) : base("TransientDependentOnDependentOnPerRequestService")
        {
            _web = web;
        }
    }


    public interface IPerWebRequestService
    {
    }

    public class PerWebRequestService : LifeTimeLogger, IPerWebRequestService
    {
        public PerWebRequestService() : base("PerWebRequestService")
        {
        }
    }

    public interface ITransientService
    {
    }

    public class TransientService : LifeTimeLogger, ITransientService
    {

        public TransientService() : base("TransientService")
        {
        }
    }


}