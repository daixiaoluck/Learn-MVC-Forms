using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Validation;

namespace WebApplication1.Models.ViewModels
{
    public class IndexHomeViewModel
    {
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "Please input Chinese characters.")]
        [Required]
        [Display(Name = "Family Name")]
        [MaxLength(2)]
        public string FamilyName { get; set; }
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "Please input Chinese characters.")]
        [Required]
        [Display(Name = "First Name")]
        [MaxLength(2)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        [MustBeChecked]
        [Display(Name = "This checkbox")]
        public bool Noticed { get; set; }
        public ApplicationUser.GenderTraversal Gender { get; set; }
        [Display(Name = "Location")]
        public int SelectedValue { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }
    }
}