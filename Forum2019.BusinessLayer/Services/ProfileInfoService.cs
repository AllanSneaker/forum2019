using AutoMapper;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using ForumEpam2019.Entities.Interfaces;

namespace ForumEpam2019.BusinessLayer.Managers
{
    public class ProfileInfoService : IProfileInfoService
    {
        private readonly IMapper _autoMapper = Mapper.Instance;
        private IUnitOfWork Database { get; }
        public ProfileInfoService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<ProfileInfoDto> GetAllProfileInfos()
        {
            return _autoMapper.Map<IEnumerable<ProfileInfoDto>>(Database.ProfileInfos.GetAll());
        }

        public ProfileInfoDto GetProfileInfo(int id)
        {
            return _autoMapper.Map<ProfileInfoDto>(Database.ProfileInfos.Get(id));
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
            //return Database.ProfileInfos.Any(p => p.Id == id);
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
