using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class Passenger
    {
        public string Name { get; set; }
        public int TargetFloor { get; }

        public Passenger(string name, int targetFloor)
        {
            this.Name = name;
            this.TargetFloor = targetFloor;
        }
    }
}
