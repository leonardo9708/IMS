using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string SupportUser { get; set; }
        public string Status { get; set; }
    }
}
