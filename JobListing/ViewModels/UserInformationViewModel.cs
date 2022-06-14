using JobListing.Enum;
using JobListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.ViewModels
{
    public class UserInformationViewModel 
    {
        public int WorkerId { get; set; }
        public string CurrentUserId { get; set; }

        [Required(ErrorMessage = "Vänligen skriv i ditt förnamn")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vänligen skriv i ditt efternamn")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "Emailadressen är skriven i fel format")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Du måste välja en stad")]
        public City City { get; set; }
        public string CityTest { get; set; }



        [Required(ErrorMessage = "Du måste skriva i en jobtitel")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Du måste välja en branch")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Du måste skriva en kort beskrivning")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Du måste skriva en lång beskrivning")]
        public string LongDescription { get; set; }



        //[Required(ErrorMessage = "Du måste välja din högsta utbildningsnivå")]
        public Education Education { get; set; }

        [Required(ErrorMessage = "Du måste välja erfarenhet (år)")]
        public WorkExperienceEnum WorkExperience { get; set; } 

        //[Required(ErrorMessage = "Du måste välja vad du söker för jobtyp")]
        public List<WorkTypes> WorkTypes { get; set; } = new List<WorkTypes>();


        public string Img { get; set; }
        public IFormFile ImageFile { get; set; } //rename ImageFile
        public IFormFile FileOne { get; set; }
        public IFormFile FileTwo { get; set; }
        public IFormFile FileThree { get; set; }
        public List<Files> files { get; set; }


        public List<Education> EducationList { get; set; }
        public List<SelectListItem> WorkTypeList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }

        [PersonalData]
        public string DisplayName => $"{FirstName} {LastName}";


    }
}
