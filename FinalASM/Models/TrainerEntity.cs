using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class TrainerEntity
    {
        public TrainerEntity()
        {
            ListCourse = new List<CourseEntity>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Need to input Pass")]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Education { get; set; }

        public string WorkingPlace { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public int CourseAssignId { get; set; }
        public List<CourseEntity> ListCourse { get; set; }

        public string ToSeparatedString(string separator)
        {
            return $"{this.Id}{separator}" +
                $"{this.Name}{separator}" +
                $"{this.Type}{separator}" +
                $"{this.Education}{separator}" +
                $"{this.WorkingPlace}";
        }

    }
}