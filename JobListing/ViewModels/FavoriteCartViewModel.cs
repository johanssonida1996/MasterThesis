using JobListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.ViewModels
{
    public class FavoriteCartViewModel
    {
        public FavoriteCart FavoriteCart { get; set; }
        public decimal FavoriteCartTotal { get; set; }
    }
}
