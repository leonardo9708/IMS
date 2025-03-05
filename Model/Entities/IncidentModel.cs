using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    class IncidentModel
    {
        public int Id { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public string? Comments { get; set; }
        public string? SupportUser { get; set; }
        public required string Status { get; set; }
    }
}
