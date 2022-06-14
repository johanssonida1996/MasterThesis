using JobListing.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class Worker 
    {
        public int Id { get; set; }
        public string CurrentUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

       
        public string JobTitle { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public int EducationId { get; set; }
        public virtual Education Education { get; set; }
        public string WorkExperience { get; set; }


        public string ImageUrl { get; set; }
        public virtual List<Files> Files { get; set; }

        public bool PopularWorker { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<WorkTypesWorker> WorkTypes { get; set; } = new HashSet<WorkTypesWorker>();
        //public List<SelectListItem> WorkTypeList { get; set; }


        [PersonalData]
        public string DisplayName => $"{FirstName} {LastName}";

    }
}
