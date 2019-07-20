using ForumEpam2019.BusinessLayer.Managers;
using ForumEpam2019.BusinessLayer.Repository;
using ForumEpam2019.Entities.Interfaces;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Repositories;
using Unity;
using Unity.Injection;
using Unity.WebApi;
using Unity.Lifetime;
using Unity.AspNet.Mvc;

namespace ForumEpam2019.BusinessLayer.Configurations
{
    public static class UnityConfig 
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //container.RegisterType<IUnitOfWork,UnitOfWorkEF>(new HierarchicalLifetimeManager(),
            //     new InjectionConstructor());

            //container.RegisterType<IUnitOfWork, UnitOfWorkEF>(new PerRequestLifetimeManager(),
            //    new InjectionConstructor("name=ForumContext"));
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));

            container.RegisterType<IProfileInfoRepository, ProfileInfoManager>();
            return container;
        }
    }
}
