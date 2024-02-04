using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanEverything.Models
{
    public class Plan
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public object Icon { get; set; }

        public Plan()
        {
            Icon = "\uf08d";
        }
    }
}
