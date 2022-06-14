using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class Company 
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<FavoriteCartItem> FavoriteItems { get; set; }
    }
}
