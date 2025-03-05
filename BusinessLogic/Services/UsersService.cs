using BusinessLogic.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IUsersService
    {
        Task<List<UsersModel>> GetUsers();
    }

    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        public Task<List<UsersModel>> GetUsers()
        {
            return usersRepository.GetUsers();
        }
    }
}
