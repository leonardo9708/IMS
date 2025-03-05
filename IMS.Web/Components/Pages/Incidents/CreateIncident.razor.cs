using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Model.Entities;
using Model.Models;

namespace IMS.Web.Components.Pages.Incidents
{
    public partial class CreateIncident
    {
        public IncidentModel IncidentModel { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set;}
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        public async Task Submit()
        {
            var res = await ApiClient.PostAsync<BaseResponseModel, IncidentModel>("/api/Incident/CreateIncident", IncidentModel);
            if(res != null && res.Success)
            {
                ToastService.ShowSuccess("Create Incident successfully");
                NavigationManager.NavigateTo("/incidents");
            }
        }
    }
}
