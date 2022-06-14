using JobListing.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Models
{
    public class WorkTypes
    {
        public int Id { get; set; }
        public string WorkTypesName { get; set; }
        //public bool IsSelected { get; set; } //ta bort, skapa WorkTypesViewModel där denna finns med

        //public virtual List<Worker> Workers { get; set; }


    }
}
