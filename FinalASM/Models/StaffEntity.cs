using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class StaffEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}