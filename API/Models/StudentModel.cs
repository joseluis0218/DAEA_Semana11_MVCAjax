using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class StudentModel
    {
        [Key]
        public int studentID { get; set; }
        [Required]
        public string studentCode { get; set; }
        [Required]
        public string studentName { get; set; }
        [Required]
        public string studentLastName { get; set; }
        [Required]
        public string studentAddress { get; set; }
        public bool? active { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updateAt { get; set; }
    }
}