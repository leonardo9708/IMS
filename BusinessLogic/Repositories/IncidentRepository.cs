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
        Task<IncidentModel> CreateProduct(IncidentModel incidentModel);
    }

    public class IncidentRepository(AppDbContext appDbContext) : IIncidentRepository
    {
        public async Task<IncidentModel> CreateProduct(IncidentModel incidentModel)
        {
            appDbContext.Incident.Add(incidentModel);
            await appDbContext.SaveChangesAsync();
            return incidentModel;
        }

        public Task<List<IncidentModel>> GetIncidents()
        {
            return appDbContext.Incident.ToListAsync();
        }
    }
}
