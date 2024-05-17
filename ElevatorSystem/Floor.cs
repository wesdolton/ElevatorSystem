using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class Floor
    {
        public int Level { get; }
        public virtual List<Passenger> Passengers { get; } = new List<Passenger>();

        public Floor(int level)
        {
            this.Level = level;
        }
    }
}
