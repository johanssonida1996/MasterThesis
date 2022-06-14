using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    interface IEducationRepository
    {
        IEnumerable<Education> AllEducations { get; }

    }
}
