using Data;

namespace WebApplication1.Services
{
    public abstract class BaseContextLogic
    {
        protected readonly ServiceContext _serviceContext;
        protected BaseContextLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }
    }
}
