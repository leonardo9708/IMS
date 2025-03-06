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
        Task<IncidentModel> GetIncidents(int id);
        Task<bool> IncidentModelExist(int id);
        Task UpdateIncident(IncidentModel incidentModel);
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

        public Task<IncidentModel> GetIncidents(int id)
        {
            return appDbContext.Incident.FirstOrDefaultAsync(n => n.Id == id);
        }

        public Task<bool> IncidentModelExist(int id)
        {
            return appDbContext.Incident.AnyAsync(n => n.Id == id);
        }

        public async Task UpdateIncident(IncidentModel incidentModel)
        {
            appDbContext.Entry(incidentModel).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
        }
    }
}
