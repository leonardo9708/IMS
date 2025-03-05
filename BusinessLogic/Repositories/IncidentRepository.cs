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
    public interface IIncidentRepository
    {
        Task<List<IncidentModel>> GetIncidents();
    }

    public class IncidentRepository(AppDbContext appDbContext) : IIncidentRepository
    {
        public Task<List<IncidentModel>> GetIncidents()
        {
            return appDbContext.Incident.ToListAsync();
        }
    }
}
