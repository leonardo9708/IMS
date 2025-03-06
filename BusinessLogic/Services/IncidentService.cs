using BusinessLogic.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IIncidentService
    {
        Task<List<IncidentModel>> GetIncidents();
        Task<IncidentModel> CreateProduct(IncidentModel incidentModel);
        Task<IncidentModel> GetIncidents(int id);
        Task<bool> IncidentModelExist(int id);
        Task UpdateIncident(IncidentModel incidentModel);
        Task DeleteIncident(int id);
    }

    public class IncidentService(IIncidentRepository incidentRepository) : IIncidentService
    {
        public Task<IncidentModel> CreateProduct(IncidentModel incidentModel)
        {
            return incidentRepository.CreateProduct(incidentModel);
        }

        public Task DeleteIncident(int id)
        {
            return incidentRepository.DeleteIncident(id);
        }

        public Task<List<IncidentModel>> GetIncidents()
        {
            return incidentRepository.GetIncidents();
        }

        public Task<IncidentModel> GetIncidents(int id)
        {
            return incidentRepository.GetIncidents(id);
        }

        public Task<bool> IncidentModelExist(int id)
        {
            return incidentRepository.IncidentModelExist(id);
        }

        public Task UpdateIncident(IncidentModel incidentModel)
        {
            return incidentRepository.UpdateIncident(incidentModel);
        }
    }
}
