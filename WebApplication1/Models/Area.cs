using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Area
    {
        [Key]
        [Display(Name = "Your location:")]
        public int Value { get; set; }
        public string Text { get; set; }
    }
}