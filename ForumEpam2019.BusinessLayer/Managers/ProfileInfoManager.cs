using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.Entities.Context;

namespace ForumEpam2019.BusinessLayer.Managers
{
  public  class ProfileInfoManager : IDisposable
    {
        private IMapper autoMapper = Mapper.Instance;
        private ForumContext context;

        public ProfileInfoManager()
        {
            context = new ForumContext();
        }

        public IEnumerable<ProfileInfoDTO> GetAllProfileInfos()
        {
            return autoMapper.Map<IEnumerable<ProfileInfoDTO>>(context.ProfileInfos.OrderByDescending(p => p.Id)).ToList();
        }

        public ProfileInfoDTO GetProfileInfo(int id)
        {
            return autoMapper.Map<ProfileInfoDTO>(context.ProfileInfos.Where(p => p.Id == id).FirstOrDefault());
        }

        public bool ProfileInfoExist(int id)
        {
            return context.ProfileInfos.Any(p => p.Id == id);
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
