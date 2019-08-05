using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.BusinessLayer.Managers;
using ForumEpam2019.BusinessLayer.Services;
using ForumEpam2019.Entities.Interfaces;
using ForumEpam2019_Entities.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumEpam2019.BusinessLayer.Configurations
{
    public class NinjectConfig : NinjectModule
    {
        private readonly string _connectionString;

        public NinjectConfig(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            //connections UOW
            Bind<IUnitOfWork>().To<UnitOfWorkEF>().WithConstructorArgument(_connectionString);
            //Bind<ForumContext>().ToSelf().InRequestScope();
            //Bind<IUnitOfWork>().To<UnitOfWorkEF>().InRequestScope();


            //services
            Bind<IProfileInfoService>().To<ProfileInfoService>().InRequestScope();
            Bind<IPostService>().To<PostService>().InRequestScope();
            Bind<ICommentService>().To<CommentService>().InRequestScope();


        }
    }
}
