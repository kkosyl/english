using English.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using English.Dal.Model;
using English.Dal.Repository;
using English.Dal;
using English.Core.DTO.GET;
using English.Core.DTO.POST;

namespace English.Service.Infrastructures
{
    public class UserService : IUserService
    {
        private IRepository<User> _user;
        private IUnitOfWork _unitOfWork;


        public UserService(IRepository<User> user, IUnitOfWork unitOfWork)
        {
            _user = user;
            _unitOfWork = unitOfWork;
        }


        public UserDetailsDto Get(int id)
        {
            var user = _user.Get(id);
            return new UserDetailsDto 
            {
                Id = user.Id,
                Email = user.Email,
                LastLoginDate = user.LastLoginDate,
                Login = user.Login,
                Password = user.Password,
                RegisterDate = user.RegisterDate
            };
        }


        public UserDetailsDto Get(string login)
        {
            var user = _user.GetAll().First(u => u.Login == login);
            return new UserDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                LastLoginDate = user.LastLoginDate,
                Login = user.Login,
                Password = user.Password,
                RegisterDate = user.RegisterDate
            };
        }


        public void UpdateLastLoginDate(int id)
        {
            var user = _user.Get(id);
            user.LastLoginDate = DateTime.Now;
            _user.Update(user);
            _unitOfWork.Commit();
        }


        public void UpdateUserDetails(UserDetailsDto user)
        {
            User updated = new User
            {
                Id = user.Id,
                Email = user.Email,
                LastLoginDate = user.LastLoginDate,
                Password = user.Password,
                RegisterDate = user.RegisterDate,
                Login = user.Login
            };
            _user.Update(updated);
            _unitOfWork.Commit();
        }


        public void RegisterUser(RegisterUserDto user)
        {
            _user.Add(new User
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RegisterDate = DateTime.Now
            });
            _unitOfWork.Commit();
        }
    }
}
