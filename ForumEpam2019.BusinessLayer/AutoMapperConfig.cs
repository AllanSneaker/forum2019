using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.Entities.Models;

namespace ForumEpam2019.BusinessLayer
{
   public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProfileInfo, ProfileInfoDTO>();
        }

        public static void Initialize()
        {
            Mapper.Initialize(cnf => cnf.AddProfile<AutoMapperConfig>());
        }
    }
}
