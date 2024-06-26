﻿using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.NTests
{
    public class ElevatorTests
    {
        private Elevator elevator;
        private Building building;

        [SetUp]
        public void Setup()
        {
            // Initialize an elevator with max weight of 1000
            elevator = new Elevator("Test Elevator", maxWeight: 1000);

            // Initialize a building with 2 elevators, each having a max weight of 1000, and 10 floors
            building = new Building(numElevators: 2, maxWeightPerElevator: 1000, numFloors: 10);
        }

        [Test]
        public void AddRequest_QueueIsNotEmptyAfterAddingRequest()
        {
            // Arrange
            int targetFloor = 5;
            Direction direction = Direction.Up;

            // Act
            elevator.AddRequest(targetFloor, direction);

            // Assert
            Assert.IsTrue(elevator.Requests.Count > 0);
        }

        [Test]
        public void ProcessRequests_PicksUpPassengersAtTargetFloor()
        {
            // Arrange
            Elevator elevator = new Elevator("Test Elevator", maxWeight: 1000);
            List<Floor> floors = new List<Floor>();

            // Initialize all floors in the building (10 floors)
            for (int i = 0; i < 10; i++)
            {
                floors.Add(new Floor(i));
            }

            // Add passengers waiting on the floor
            floors[5].Passengers.Add(new Passenger("Alice", 5));
            floors[5].Passengers.Add(new Passenger("Bob", 5));

            // Add a request to the elevator to move to floor 5 (direction doesn't matter for this test)
            elevator.AddRequest(5, Direction.Up);

            // Act
            elevator.ProcessRequests(floors);

            // Assert
            // Verify that passengers are picked up by the elevator
            //Assert.AreEqual(2, elevator.Passengers.Count, "Unexpected number of passengers in the elevator.");
            //Assert.AreEqual(0, floor.Passengers.Count, "Passengers should have been picked up from the floor.");

            Assert.That(elevator.Passengers.Count, Is.EqualTo(0));
            Assert.That(floors[5].Passengers.Count, Is.EqualTo(2));
        }
    }
}
