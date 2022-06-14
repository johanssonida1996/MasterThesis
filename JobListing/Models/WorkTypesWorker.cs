using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class WorkTypesWorker
    {
        public int Id { get; set; }
        public int WorkTypesId { get; set; }
        public int WorkerId { get; set; }

        public Worker worker { get; set; }
        public WorkTypes worktype { get; set; }

    }
}
