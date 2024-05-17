// See https://aka.ms/new-console-template for more information
using ElevatorSystem;

Building building = new Building(numElevators: 2, maxWeightPerElevator: 1000, numFloors: 10);

// Simulate elevator requests
building.CallElevator(floorNumber: 3, numPassengers: 2, direction: Direction.Up);
building.CallElevator(floorNumber: 6, numPassengers: 1, direction: Direction.Down);
building.CallElevator(floorNumber: 8, numPassengers: 3, direction: Direction.Up);

// Start the elevator simulation
building.Simulate();
