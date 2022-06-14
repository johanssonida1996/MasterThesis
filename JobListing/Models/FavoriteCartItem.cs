using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class FavoriteCartItem
    {
        public int FavoriteCartItemId { get; set; }
        public Worker Worker { get; set; }
        public string FavoriteCartId { get; set; }
    }
}
