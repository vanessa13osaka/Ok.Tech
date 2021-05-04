using Ok.Tech.Domain.Repositories;

namespace Ok.Tech.App
{
    public abstract class AppBase
    {

        public AppBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }
    }

        

    
}
