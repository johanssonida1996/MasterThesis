using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class Files
    {
        public int WorkerId { get; set; }
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
