
﻿using System.Reflection;

namespace Containers;

public class Ship
{
    public List<Container> Containers { get; set; } = new List<Container>();
    public double maxSpeed { get; set; }
    public int maxContainers { get; set; }
    public double maxWeight { get; set; }

    public Ship(double maxSpeed, int maxContainers, double maxWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainers = maxContainers;
        this.maxWeight = maxWeight;
    }

    public void loadContainer(Container container)
    {
        if (((getAllContainersWeight() + container.ownWeight + container.cargoMass) <= maxWeight) &&
            (Containers.Count + 1 < maxContainers))
        {
            Containers.Add(container);
        }
        else
        {
            // Console.WriteLine("Ship max weight exceeded - Operation was not performed");
            throw new OverfillException(
                "Ship max weight / max containers number exceeded - Operation was not performed");
        }
    }

    public void loadContainer(List<Container> containers)
    {
        double containersListWeight = 0;

        foreach (Container container in containers)
        {
            containersListWeight = containersListWeight + container.ownWeight + container.cargoMass;
        }

        if (((getAllContainersWeight() + containersListWeight) < maxWeight) && ((Containers.Count + containers.Count) <= maxContainers))
        {
            foreach (Container container in containers)
            {
                Containers.Add((container));
            }
        }
        else
        {
            // Console.WriteLine("Ship max weight exceeded - Operation was not performed");
            throw new OverfillException(
                "Ship max weight / max containers number exceeded - Operation was not performed");
        }
    }

    public void removeContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void replaceContainer(int containerToReplaceIndex, Container replacingContainer)
    {
        if (((getAllContainersWeight() - (Containers[containerToReplaceIndex].ownWeight +
                                          Containers[containerToReplaceIndex].cargoMass) +
              replacingContainer.ownWeight +
              replacingContainer.cargoMass) < maxWeight) && ((Containers.Count + 1) <= maxContainers))
        {
            Containers[containerToReplaceIndex] = replacingContainer;
        }
        else
        {
            throw new OverfillException(
                "Ship max weight / max containers number exceeded - Operation was not performed");
        }
    }

    public static void moveContainerBetweenShips(Ship fromShip, Ship toShip, Container containerToMove)
    {
        if (((toShip.getAllContainersWeight() + containerToMove.ownWeight + containerToMove.cargoMass) <
             toShip.maxWeight) && ((toShip.Containers.Count + 1) <= toShip.maxContainers))
        {
            fromShip.removeContainer(containerToMove);
            toShip.loadContainer(containerToMove);
        }
        else
        {
            throw new OverfillException(
                "Ship max weight / max containers number exceeded - Operation was not performed");
        }
    }

    private double getAllContainersWeight()
    {
        double result = 0;
        foreach (Container container in Containers)
        {
            result = result + container.cargoMass + container.ownWeight;
        }

        return result;
    }

    public void getShipInfo()
    {
        Console.WriteLine(
            $"All information about ship -> Max Speed: {maxSpeed} knots; Max Containers: {maxContainers}; Max Weight: {maxWeight} kg");

        Console.WriteLine("Information about containers onboard:");
        foreach (Container container in Containers)
        {
            Console.WriteLine(container);
        }
    }
}
