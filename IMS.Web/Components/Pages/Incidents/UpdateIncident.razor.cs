using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Model.Entities;
using Model.Models;
using Newtonsoft.Json;

namespace IMS.Web.Components.Pages.Incidents
{
    public partial class UpdateIncident : ComponentBase
    {
        [Parameter]
        public int ID { get; set; }
        public IncidentModel IncidentModelU { get; set; } = new();
        [Inject]
        private ApiClient ApiClient { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>($"api/Incident/{ID}");
            if(res != null && res.Success)
            {
                IncidentModelU = JsonConvert.DeserializeObject<IncidentModel>(res.Data.ToString());
            }
        }

        public async Task Submit()
        {
            var res = await ApiClient.PutAsync<BaseResponseModel, IncidentModel>($"/api/Incident/{ID}", IncidentModelU);
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Update incident succeessfully");
                NavigationManager.NavigateTo("/incidents");
            }
        }
    }
}
