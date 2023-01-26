using CarparkDemo;

// spot doesn't have a vehicle parked, doesn't belong to a carpark
//ParkingSpot newSpot = new ParkingSpot(6);
CarPark newPark = new CarPark(10);
Vehicle newVehicle = new Vehicle("A1A1A1");
Vehicle vehicleTwo = new Vehicle("B2B2B2");
Vehicle vehicleThree = new Vehicle("C3C3C3");

// add the new parking spot to the new carpark
// currently, the carpark capacity has a value of int 10
// readonly = cannot reassign
// newPark.Capacity = 12; not allowed by compiler

// ParkingSpots is a single reference to a hashset
// because there is no set method on its property, it cannot be reassigned
// newPark.ParkingSpots = new HashSet<ParkingSpot>(); not allowed by the compiler

// not reassigning the field value
// invoking a method on the field value
// allowed by the get method
// newPark.ParkingSpots.Clear(); allowed by the compiler

// cannot access the parking spot list -- only add a new spot
//newPark.AddParkingSpot(newSpot);

// count the number of spots to confirm that adding worked
Console.WriteLine(newPark.GetParkingSpots().Count);

// created a reference from one object to another that allows us to refer to objects by each other
//Console.WriteLine(newSpot.CarPark.GetParkingSpots().Count());

// new spot has a reference to the new park
//Console.WriteLine(newSpot.CarPark == newPark);

// new park has a reference to the new spot
//Console.WriteLine(newPark.GetParkingSpots().First() == newSpot);

newPark.ParkVehicle(newVehicle, newPark);
newPark.ParkVehicle(vehicleTwo, newPark);
newPark.ParkVehicle(vehicleThree, newPark);
Console.WriteLine();

newPark.RemoveVehicle(vehicleTwo);

