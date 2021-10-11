using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalASM.Models
{
    public class CourseCategoryEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Need Input Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseEntity> ListCourse { get; set; }
    }
}