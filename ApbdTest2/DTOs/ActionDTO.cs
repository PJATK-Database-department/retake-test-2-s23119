using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.DTOs
{
    public class ActionDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int NumberOfFirefighters { get; set; }

        public DateTime VehicleAssigned { get; set; }
    }
}
