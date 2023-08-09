using System;
using System.Collections.Generic;

namespace Аквариум
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string COmmandCompliteProgram = "1";

            Aquarium aquarium = new Aquarium();

            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                aquarium.Work();

                Console.WriteLine($"{COmmandCompliteProgram} - завершить программу");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case COmmandCompliteProgram:
                        isWork = false;
                        break;

                    default:
                        continue;
                }
            }
        }
    }

    class Fish
    {
        public Fish(string name, int age, int ageDeath)
        {
            Name = name;
            Age = age;
            AgeDeath = ageDeath;
            IsAlive = true;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int AgeDeath { get; private set; }
        public bool IsAlive { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, возраст {Age}, жива ли {IsAlive}");
        }

        public int AddYearLife()
        {
            if (Age < AgeDeath)
            {
                Age++;
                return Age;
            }
            else if (Age == AgeDeath)
            {
                IsAlive = false;
                Age = AgeDeath;
            }

            return Age;
        }
    }

    class FishFactory
    {
        public Fish CreateRandom()
        {
            List<Fish> fishes = new List<Fish>()
            {
            new Fish("Гуппи", 1, 17),
            new Fish("Скалярия", 1, 12),
            new Fish("Барбус", 1, 18),
            new Fish("Данио", 1, 13),
            new Fish("Анциструс", 1, 16),
            new Fish("Моллинезия", 1, 19),
            new Fish("Тернеция", 1, 15),
            new Fish("Сом", 1, 14)
            };

            int fishInddex = Utils.GetRandomValue(fishes.Count);

            return fishes[fishInddex];
        }
    }

    class Aquarium
    {
        private List<Fish> _listFishes = new List<Fish>();

        private FishFactory _fishFactory = new FishFactory();

        private int _aquariumCapacity = 7;

        private void ShowInfo()
        {
            for (int i = 0; i < _listFishes.Count; i++)
            {
                _listFishes[i].ShowInfo();
            }
        }

        private void AddRandomFishes()
        {
            for (int i = 0; i < _aquariumCapacity; i++)
            {
                if (_listFishes.Count != _aquariumCapacity)
                {
                    _listFishes.Add(_fishFactory.CreateRandom());
                    _listFishes[i].ShowInfo();
                }
            }
        }

        private void AddYearLife()
        {
            for (int i = 0; i < _listFishes.Count; i++)
            {
                _listFishes[i].AddYearLife();
            }
        }

        private void RemoveDeadFishes()
        {
            for (int i = 0; i < _listFishes.Count; i++)
            {
                if (_listFishes[i].IsAlive == false)
                {
                    Console.Write($"Рыбка ");
                    _listFishes[i].ShowInfo();
                    Console.WriteLine("Умерла и удалена из Аквариума");
                    _listFishes.RemoveAt(i);
                }
            }
        }

        public void Work()
        {
            AddRandomFishes();
            ShowInfo();
            AddYearLife();
            RemoveDeadFishes();
        }
    }
    public static class Utils
    {
        private static Random _random = new Random();

        public static int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public static int GetRandomValue(int value)
        {
            return _random.Next(value);
        }
    }
}
