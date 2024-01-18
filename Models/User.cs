using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_Using_Repository.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        [Display(Name="Pin Code")]
        public int PinCode { get; set; }
        [Display(Name="Active")]
        public bool IsActive { get; set; }
    }
}
