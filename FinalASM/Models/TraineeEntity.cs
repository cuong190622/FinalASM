using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class TraineeEntity
    {
        public TraineeEntity()
        {
            listCourse = new List<CourseEntity>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Need to input name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Need to input Pass")]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }
        public string Education { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        public string ProgrammingLanguage { get; set; }

        public float Toeic { get; set; }

        public string Experience { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        public int CourseAssignId { get; set; }

        public List<CourseEntity> listCourse { get; set; }
    }
}