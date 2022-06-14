using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
        public bool IsSelected { get; set; }

        public List<Worker> Workers { get; set; }

    }
}
