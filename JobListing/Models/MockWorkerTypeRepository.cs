using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class MockWorkerTypeRepository
    {
        public IEnumerable<WorkTypes> AllWorkTypes =>
          new List<WorkTypes>
          {
                new WorkTypes{Id=1, WorkTypesName="Heltid"},
                new WorkTypes{Id=2, WorkTypesName="Deltid"},
                new WorkTypes{Id=3, WorkTypesName="Visstid/Projekt"},
                new WorkTypes{Id=4, WorkTypesName="Praktik"}
 
          };
    }
}

