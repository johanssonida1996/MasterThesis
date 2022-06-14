using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Worker> Workers { get; set; }
    }
}
