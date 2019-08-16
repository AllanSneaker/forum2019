using AutoMapper;
using ForumEpam2019.BusinessLayer.Configurations;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.ServiceLayer.Models;

namespace ForumEpam2019.ServiceLayer.App_Start
{
    public class AutoMapperConfigurations
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                AutoMapperConfig.Configure(cfg);
                AutoMapperConfigurations.Configure(cfg);
            });
        }

        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CommentModel, CommentDto>().ReverseMap();
        }
    }
}