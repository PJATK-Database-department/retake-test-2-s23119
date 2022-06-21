using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.DTOs
{
    public class GetFireTruckResponse
    {
        public FireTruckDTO FireTruck { get; set; }
        public ICollection<ActionDTO> FireTruckActions { get; set; }
    }
}
