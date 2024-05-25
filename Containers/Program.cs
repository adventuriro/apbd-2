using System.Threading.Channels;
using Containers;

GasContainer gasContainer = new GasContainer(6, 5, 5, 5, 15, 5);
LiquidContainer liquidContainer = new LiquidContainer(0, 5, 5, 5, 15, true);
RefrigeratorContainer refrigeratorContainer = new RefrigeratorContainer(7.8, 23, 45.5, 12.5, 123, "Bananas", 16.5);


Console.WriteLine();
Console.WriteLine("Load container:");
Console.WriteLine($"Cargo mass before: {liquidContainer.cargoMass}");
liquidContainer.loadCargo(5);

// Overfill exception
// liquidContainer.loadCargo(55);
Console.WriteLine($"Cargo mass after: {liquidContainer.cargoMass}");



Console.WriteLine();
Console.WriteLine("Load single container:");
Ship firstShip = new Ship(5.1, 3, 500);
firstShip.loadContainer(gasContainer);

firstShip.getShipInfo();



Console.WriteLine();
Console.WriteLine("Load list of containers:");

List<Container> myContainers = new List<Container>();
myContainers.Add(liquidContainer);
myContainers.Add(refrigeratorContainer);

firstShip.loadContainer(myContainers);

firstShip.getShipInfo();



Console.WriteLine();
Console.WriteLine("Remove container from ship:");

firstShip.removeContainer(refrigeratorContainer);
firstShip.getShipInfo();



Console.WriteLine();
Console.WriteLine("Unload container:");

gasContainer.unloadCargo();
Console.WriteLine(gasContainer);



Console.WriteLine();
Console.WriteLine("Replace container:");

// Invalid product excepction
// RefrigeratorContainer newRefrigeratorContainer = new RefrigeratorContainer(8.8, 23, 45.5, 12.5, 123, "Jarek", 16.5);

// Invalid temperature excepction
// RefrigeratorContainer newRefrigeratorContainer = new RefrigeratorContainer(8.8, 23, 45.5, 12.5, 123, "Bananas", 11.5);


RefrigeratorContainer newRefrigeratorContainer = new RefrigeratorContainer(18.8, 83, 45.5, 152.5, 123, "fish", 5);
firstShip.getShipInfo();
Console.WriteLine();

firstShip.replaceContainer(0, newRefrigeratorContainer);

firstShip.getShipInfo();



Console.WriteLine();
Console.WriteLine("Move container between ships:");

Ship secondShip = new Ship(7.2, 5, 250);
Ship.moveContainerBetweenShips(firstShip, secondShip, liquidContainer);

firstShip.getShipInfo();
secondShip.getShipInfo();



Console.WriteLine();
Console.WriteLine("Get full info about single container: ");
Console.WriteLine(liquidContainer);



Console.WriteLine();
Console.WriteLine("Printing information about ships was used in almost every data display :)");