using JobListing.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.ViewModels
{
    public class WorkerListViewModel
    {
        public IEnumerable<Worker> Workers { get; set; }
        public IEnumerable<Worker> PopularWorkers { get; set; }
        public Worker Worker { get; set; }

        public string CurrentCategory { get; set; }
        public string CurrentCity { get; set; }

        public string SearchString { get; set; }


        public List<SelectListItem> WorkTypeList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

    }
}
