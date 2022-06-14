using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class MockEducationRepository
    {
        public IEnumerable<Education> AllEducations =>
         new List<Education>
         {
                new Education { EducationId = 11, EducationName = "Gymnasieutbildning" },
                new Education { EducationId = 12, EducationName = "Universitets- och Högskoleutbildning" },
                new Education { EducationId = 13, EducationName = "Yrkeshögskoleutbildning" },
                new Education { EducationId = 14, EducationName = "Komvux / Vuxenutbildning" },
                new Education { EducationId = 15, EducationName = "Folkhögskoleutbildning" },
                new Education { EducationId = 16, EducationName = "Kurs eller övrig utbildning" }

         };
    }
}
