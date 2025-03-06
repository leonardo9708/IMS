using Blazored.Toast.Services;
using IMS.Web.Components.BaseComponents;
using Microsoft.AspNetCore.Components;
using Model.Entities;
using Model.Models;
using Newtonsoft.Json;

namespace IMS.Web.Components.Pages.Incidents
{
    public partial class IndexIncident
    {
        [Inject]
        public ApiClient ApiClient { get; set; }
        public List<IncidentModel> IncidentModels { get; set; }
        public AppModal Modal { get; set; }
        public int DeleteId { get; set; }
        [Inject]
        private IToastService ToastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadProduct();
        }

        protected async Task LoadProduct()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Incident/GetIncident");
            if (res != null)
            {
                IncidentModels = JsonConvert.DeserializeObject<List<IncidentModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }

        protected async Task Delete()
        {
            var res = await ApiClient.DeleteAsync<BaseResponseModel>($"/api/Incident/{DeleteId}");
            if (res != null && res.Success)
            {
                ToastService.ShowSuccess("Delete incident successfully");
                await LoadProduct();
                Modal.Close();
            }
        }
    }
}
