using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace studentmanagement
{
    public class Student
    {
        [Required]
        [StringLength(255)]
        public String FirstName { get; set; }

       
        
        public int studentId { get; set; }
        
        [StringLength(25)]
        public String LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public  String DateofBirth { get; set; }
       
        [StringLength(2000)]
        public String Address { get; set; }

        [Required]
        [Range(111,9999999999)]
        public long PhoneNumber { get; set; }
        public String Course { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public string EnrollmentDate { get; set; }
    }
}
