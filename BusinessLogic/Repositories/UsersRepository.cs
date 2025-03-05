using DataBase.Data;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IUsersRepository
    {
        Task<List<UsersModel>> GetUsers();
    }

    public class UsersRepository(AppDbContext appDbContext) : IUsersRepository
    {
        public Task<List<UsersModel>> GetUsers()
        {
            return appDbContext.SupportUsers.ToListAsync();
        }
    }
}
