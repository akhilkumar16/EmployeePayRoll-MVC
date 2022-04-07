using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
   public class EmployeeModel
    {
        //model class based on the database;
        public int EmpId { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Z a-z]{2,}$")]// validation of text entered by user;
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public long Salary { get; set; }
        public DateTime? Startdate { get; set; }
        public string Notes { get; set; }
    }
}
