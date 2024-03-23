namespace ConsoleApp2;

public class Ship
    {
        public List<Container> Containers { get; private set; }
        public double Speed { get; }
        public int Num { get; }
        public int MaxConainers { get;  }
        public double MaxCargo { get; }
        private double Cargo;

        public Ship(double speed, int maxConainers, double maxCargo)
        {
            Speed = speed;
            MaxConainers = maxConainers;
            MaxCargo = maxCargo;
            Containers = new List<Container>();
            Num = Counter++;
        }

        public void addContainer(Container container)
        {
            if ((Cargo + container.CargoWeight + container.ContainerWeight <= MaxCargo) &&
                (Containers.Count < MaxConainers))
            {
                Containers.Add(container);
                Cargo += container.ContainerWeight + container.CargoWeight;
            }
            else
            {
                throw new Exception("Adding container is not possible.Ship capacity is not so large");
            }
        }

        public void Remove(string serialNumber)
        {
            Container removeContainer = Containers.Find(container => container.SerialNumber == serialNumber);
            if (removeContainer != null)
            {
                Containers.Remove(removeContainer);
                Cargo -= removeContainer.CargoWeight + removeContainer.ContainerWeight;
            }
        }

        public void LoadContainers(List<Container> containers)
        {
            foreach (var container in containers)
            {
                addContainer(container);
            }
        }

        public void Replace(string serialNumber, Container Container2)
        {
            Remove(serialNumber);
            addContainer(Container2);
        }

        public void unload(string serialNumber)
        {
            Container unloadContainer = Containers.Find(container => container.SerialNumber == serialNumber);
            if (unloadContainer != null)
            {
                unloadContainer.Unload();
                Cargo -= unloadContainer.CargoWeight;
            }
        }

        public void changeShip(Ship ship, string serialNumber)
        {
            Container changeContainer = Containers.Find(container => container.SerialNumber == serialNumber);
            if (changeContainer != null)
            {
                ship.addContainer(changeContainer);
                Remove(serialNumber);
            }
        }

        public override string ToString()
        {
            string info = $"Ship {Num}\n" + $"Speed: {Speed} knots\n" + $"Maximum number of containers: {MaxConainers}\n"
                          + $"Maximum Cargo weigth in tons: {MaxCargo}\n" + $"Cargo weight in tons right now: {Cargo}\n";
            int conCounter = 0;
            foreach (Container container in Containers)
            {
                conCounter++;
                info +=$"Serial numbers of current containers on ship: {conCounter}. {container.SerialNumber}.\n";
            }

            return info;
        }

        private static int Counter = 1;

    }


