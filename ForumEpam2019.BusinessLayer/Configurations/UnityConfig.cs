using ForumEpam2019.BusinessLayer.Managers;
using ForumEpam2019.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace ForumEpam2019.BusinessLayer.Configurations
{
    public static class UnityConfig 
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IProfileInfoRepository, ProfileInfoManager>();

            return container;
        }
    }
}
