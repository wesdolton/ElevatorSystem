using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
    public class Elevator
    {
        public string Name { get; }
        public int CurrentFloor { get; set; }
        public Direction Direction { get; set; }
        public List<Passenger> passengers { get; } = new List<Passenger>();
        public Queue<(int floor, Direction direction)> Requests { get; } = new Queue<(int floor, Direction direction)>();
        public int MaxWeight { get; }
        public Elevator( string name, int maxWeight)
        {
            this.Name = name;
            this.MaxWeight = MaxWeight;
            this.CurrentFloor = 0;
            this.Direction = Direction.Idle;
        }
        public void AddRequest(int floor, Direction direction)
        {
            this.Requests.Enqueue((floor, direction));
        }
        public void ProcessRequests(List<Floor> floors)
        {
            if (Requests.Count == 0) return;

            var (targetFloor, targetDirection) = Requests.Dequeue();
            MoveToFloor(targetFloor);
            OpenDoors();

            PickUpPassengers(targetDirection, floors[targetFloor]);

            CloseDoors();
            Direction = targetDirection;
        }
        private void MoveToFloor(int targetFloor)
        {
            if (targetFloor > CurrentFloor)
                Console.WriteLine($"{Name} moving up to floor {targetFloor}...");
            else if (targetFloor < CurrentFloor)
                Console.WriteLine($"{Name} moving down to floor {targetFloor}...");

            Thread.Sleep(Math.Abs(targetFloor - CurrentFloor) * 1000); // Simulate travel time
            CurrentFloor = targetFloor;
        }
        private void OpenDoors()
        {
            Console.WriteLine($"{Name} opening doors at floor {CurrentFloor}...");
            Thread.Sleep(1000); // Simulate door opening time
        }
        private void CloseDoors()
        {
            Console.WriteLine($"{Name} closing doors at floor {CurrentFloor}...");
            Thread.Sleep(1000); // Simulate door closing time
        }

        private void PickUpPassengers(Direction direction, Floor floor)
        {
            var passengersToPickUp = floor.Passengers.Where(p => p.TargetFloor * (int)direction > CurrentFloor * (int)direction).ToList();

            foreach (var passenger in passengersToPickUp)
            {
                Console.WriteLine($"{Name} picking up passenger {passenger.Name} at floor {CurrentFloor}...");
                Passengers.Add(passenger);
            }

            floor.Passengers.RemoveAll(p => passengersToPickUp.Contains(p));
        }

        public string GetStatus()
        {
            return $"{Name} - Floor: {CurrentFloor}, Direction: {Direction}, Passengers: {Passengers.Count}";
        }

    }
}
