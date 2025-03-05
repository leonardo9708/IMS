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

        protected override async Task OnInitializedAsync()
        {
            var res = await ApiClient.GetFromJsonAsync<BaseResponseModel>("/api/Incident/GetIncident");
            if(res != null)
            {
                IncidentModels = JsonConvert.DeserializeObject<List<IncidentModel>>(res.Data.ToString());
            }
            await base.OnInitializedAsync();
        }
    }
}
