using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Validation;

namespace WebApplication1.Models.ViewModels
{
    public class IndexHomeViewModel
    {
        [MustBeChecked]
        [Display(Name = "This checkbox")]
        public bool Noticed { get; set; }
        public ApplicationUser.GenderTraversal Gender { get; set; }
        [Display(Name = "Location")]
        public int SelectedValue { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }
    }
}