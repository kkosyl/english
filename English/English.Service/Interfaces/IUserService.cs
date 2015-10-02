using English.Core.DTO.GET;
using English.Core.DTO.POST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Service.Interfaces
{
    public interface IUserService
    {
        UserDetailsDto Get(int id);
        UserDetailsDto Get(string login);

        void UpdateLastLoginDate(int id);
        void UpdateUserDetails(UserDetailsDto user);
        void RegisterUser(RegisterUserDto user);
    }
}
