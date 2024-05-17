using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class Building
    {
        private List<Elevator> elevators = new List<Elevator>();
        private List<Floor> floors = new List<Floor>();
        public List<Floor> Floors => floors;

        public Building(int numElevators, int maxWeightPerElevator, int numFloors)
        {
            for (int i = 1; i <= numElevators; i++)
            {
                elevators.Add(new Elevator($"Elevator {i}", maxWeightPerElevator));
            }

            for (int i = 0; i < numFloors; i++)
            {
                floors.Add(new Floor(i));
            }
        }

        public Floor GetFloor(int floorNumber)
        {
            return floors[floorNumber];
        }

        public void CallElevator(int floorNumber, int numPassengers, Direction direction)
        {
            floors[floorNumber].Passengers.AddRange(
                Enumerable.Range(1, numPassengers)
                    .Select(n => new Passenger($"Passenger {n}", floorNumber))
            );

            var bestElevator = GetClosestElevator(floorNumber);
            if (bestElevator != null)
            {
                bestElevator.AddRequest(floorNumber, direction);
            }
        }

        public bool HasPendingRequest(int floorNumber)
        {
            foreach (var elevator in elevators)
            {
                if (elevator.Requests.Any(r => r.floor == floorNumber))
                    return true;
            }
            return false;
        }

        public Elevator GetClosestElevator(int floorNumber)
        {
            return elevators.OrderBy(e => Math.Abs(e.CurrentFloor - floorNumber)).First();
        }

        public void Simulate()
        {
            while (true)
            {
                Console.Clear();
                foreach (var elevator in elevators)
                {
                    elevator.ProcessRequests(floors);
                    Console.WriteLine(elevator.GetStatus());
                }
                Console.WriteLine("====================================");
                Thread.Sleep(2000); // Simulate each stop taking 2 seconds
            }
        }
    }
}
