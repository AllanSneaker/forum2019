using System.Collections.Generic;
using ForumEpam2019.BusinessLayer.DTO;

namespace ForumEpam2019.BusinessLayer.Repository
{
   public interface IProfileInfoRepository
    {
        IEnumerable<ProfileInfoDto> GetAllProfileInfos();
        ProfileInfoDto GetProfileInfo(int id);
        bool ProfileInfoExist(int id);
        bool AddProfileInfo(ProfileInfoDto profileInfoDto);
        bool EditProfileInfo(int Id, ProfileInfoDto value);
        void Dispose();
    }
}
