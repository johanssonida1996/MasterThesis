using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing.Enum
{
    public enum WorkExperienceEnum
    {
        [Display(Name = "Erfarenhet (år)")]
        Erfarenhet,
        [Display(Name = "0-1 år")]
        NollTillEtt,
        [Display(Name = "1-3 år")]
        EttTillTre,
        [Display(Name = "3-5 år")]
        TreTillFem,
        [Display(Name = "5 år >")]
        FemEllerMer

    }

    //public class DisplayText : Attribute
    //{

    //    public DisplayText(string Text)
    //    {
    //        this.text = Text;
    //    }


    //    private string text;


    //    public string Text
    //    {
    //        get { return text; }
    //        set { text = value; }
    //    }
    //}
}
