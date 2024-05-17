using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.NTests
{
    public class BuildingTests
    {
        private Building building;

        [SetUp]
        public void Setup()
        {
            // Initialize a building with 2 elevators, each having a max weight of 1000, and 10 floors
            building = new Building(numElevators: 2, maxWeightPerElevator: 1000, numFloors: 10);
        }

        [Test]
        public void CallElevator_AddsPassengersToFloorAndRequestsElevator()
        {
            // Arrange
            int floorNumber = 3;
            int numPassengers = 2;
            Direction direction = Direction.Up;

            // Act
            building.CallElevator(floorNumber, numPassengers, direction);

            // Assert
            Assert.AreEqual(numPassengers, building.GetFloor(floorNumber).Passengers.Count);
            Assert.IsTrue(building.HasPendingRequest(floorNumber));
        }

        [Test]
        public void GetClosestElevator_ReturnsClosestElevatorToFloor()
        {
            // Arrange
            int floorNumber = 5;

            // Act
            var closestElevator = building.GetClosestElevator(floorNumber);

            // Assert
            Assert.IsNotNull(closestElevator);
            Assert.AreEqual(0, closestElevator.CurrentFloor); // Both elevators start at floor 0 in our setup
        }
    }
}
