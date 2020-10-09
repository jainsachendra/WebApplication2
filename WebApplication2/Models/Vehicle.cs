using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model model { get; set; }
        public bool IsRegisterd { get; set; }
        [Required]
        [StringLength(250)]
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        [Required]
        [StringLength(250)]
        public string ContactName { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<VehicleFeature>Features{get;set;}
        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}
