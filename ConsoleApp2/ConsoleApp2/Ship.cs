﻿namespace ConsoleApp2;

public class Ship
    {
        public List<Container> Containers = new();
        public static int ShipCounter = 0;
        public int Number { get; set; }

        public Ship(double speed, int maxContainers, double maxCargoWeight)
        {
            Speed = speed;
            MaxContainers = maxContainers;
            MaxCargoWeight = maxCargoWeight;
            Number = ++ShipCounter;
        }

        private double _actualCargoWeight = 0;
        public double Speed { get; set; }
        public int MaxContainers { get; set; }
        public double MaxCargoWeight { get; set; }

        public void AddContainer(Container con)
        {
            if (Containers.Count < MaxContainers && _actualCargoWeight + con.CargoWeight + con.ContainerWeight < MaxCargoWeight)
            {
                Containers.Add(con);
                _actualCargoWeight += con.CargoWeight + con.ContainerWeight;
            }
            else
            {
                throw new Exception();
            }
        }

        public void AddContainers(List<Container> cons)
        {
            foreach (Container con in cons)
            {
                AddContainer(con);
            }
        }

        public void RemoveContainer(string name)
        {
            foreach (Container con in Containers)
            {
                if (con.SerialNumber == name)
                {
                    Containers.Remove(con);
                    _actualCargoWeight -= con.CargoWeight;
                    break;
                }
            }
        }

        public void ReplaceContainer(string name, Container con)
        {
            RemoveContainer(name);
            AddContainer(con);
        }

        public void ChangeShip(Ship targetShip, string name)
        {
            foreach (Container con in Containers)
            {
                if (con.SerialNumber == name)
                {
                    con.ChangeShip(this, targetShip);
                    break;
                }
            }
        }

        public override string ToString()
        {
            string result = $"Ship {Number}\n" +
                $"Speed {Speed}\n" +
                $"Cargo Weight {_actualCargoWeight}\n" +
                $"Max Cargo Weight {MaxCargoWeight}\n" +
                $"Max Containers {MaxContainers}\n";
            int Counter = 0;
            foreach (Container con in Containers)
            {
                Counter++;
                result += $"{Counter}. {con.SerialNumber}\n";
            }
            return result;
        }
    }
