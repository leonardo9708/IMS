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
    }

    public class IncidentService(IIncidentRepository incidentRepository) : IIncidentService
    {
        public Task<IncidentModel> CreateProduct(IncidentModel incidentModel)
        {
            return incidentRepository.CreateProduct(incidentModel);
        }

        public Task<List<IncidentModel>> GetIncidents()
        {
            return incidentRepository.GetIncidents();
        }


    }
}
