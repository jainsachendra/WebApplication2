using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
