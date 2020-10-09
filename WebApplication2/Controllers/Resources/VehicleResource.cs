using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource model { get; set; }
        public KeyValuePairResource make
        { get; set; }
        public bool IsRegisterd { get; set; }
       
        public ContactResource Contact { get; set; }
       
        public DateTime LastUpdated { get; set; }
        public ICollection<KeyValuePairResource> Features { get; set; }
        public VehicleResource()
        {
            Features = new Collection<KeyValuePairResource>();
        }
    }
}
