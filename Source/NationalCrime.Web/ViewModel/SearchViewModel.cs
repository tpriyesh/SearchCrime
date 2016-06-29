using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NationalCrime.Web.ViewModel
{
    public class SearchViewModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Nationality { get; set; }

         [Range(0, 350, ErrorMessage = "Please enter valid start height.Valid value between 0 to 350")]
        public float StartHeightRange { get; set; }
         [Range(0,350, ErrorMessage = "Please enter valid end height.Valid value between 0 to 350")]
        public float EndHeightRange { get; set; }
        [Range(0, 120, ErrorMessage = "Please enter valid start age.Valid value between 0 to 120")]
        public int StartAge { get; set; }
         [Range(0, 120, ErrorMessage = "Please enter valid end age.Valide value between 0 to 120")]
        public int EndAge { get; set; }
         [Range(0,500, ErrorMessage = "Please enter valid start weight.Valid value between 0 to 500")]
        public float StartWeightRange { get; set; }
         [Range(0, 500, ErrorMessage = "Please enter valid end weight, Valid value between 0 to 500")]
        public float EndWeightRange { get; set; }
    }
}