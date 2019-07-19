using AutoMapper;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.Entities.Models;
using ForumEpam2019_Entities.Models;

namespace ForumEpam2019.BusinessLayer.Configurations
{
   public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProfileInfo, ProfileInfoDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<HashTag, HashTagDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cnf => cnf.AddProfile<AutoMapperConfig>());
        }
    }
}
