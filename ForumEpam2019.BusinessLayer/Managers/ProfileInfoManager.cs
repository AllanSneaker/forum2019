using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Repository;
using ForumEpam2019.Entities.Context;
using ForumEpam2019.Entities.Interfaces;

namespace ForumEpam2019.BusinessLayer.Managers
{
  public  class ProfileInfoManager : IDisposable, IProfileInfoRepository
    {
        private IMapper autoMapper = Mapper.Instance;
        private ForumContext context;
        //private IUnitOfWork context;
        public ProfileInfoManager(/*IUnitOfWork unitOfWork*/)
        {
            context = new ForumContext();
        }

        public IEnumerable<ProfileInfoDto> GetAllProfileInfos()
        {
            return autoMapper.Map<IEnumerable<ProfileInfoDto>>(context.ProfileInfos.OrderByDescending(p => p.Id)).ToList();
        }

        public ProfileInfoDto GetProfileInfo(int id)
        {
            return autoMapper.Map<ProfileInfoDto>(context.ProfileInfos.Where(p => p.Id == id).FirstOrDefault());
            throw new NotImplementedException();
        }
        public bool AddProfileInfo(ProfileInfoDto profileInfoDto)
        {
            throw new NotImplementedException();
        }

        public bool EditProfileInfo(int Id, ProfileInfoDto value)
        {
            throw new NotImplementedException();
        }
        public bool ProfileInfoExist(int id)
        {
             return context.ProfileInfos.Any(p => p.Id == id);
            //throw new NotImplementedException();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
