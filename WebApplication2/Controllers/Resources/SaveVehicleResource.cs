using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication2.Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model model { get; set; }
        public bool IsRegisterd { get; set; }
        public ContactResource Contact { get; set; }
        public ICollection<int> features { get; set; }
        public SaveVehicleResource(){
            features = new Collection<int>();
        }

    }
}
