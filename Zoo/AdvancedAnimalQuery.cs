using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class AdvancedAnimalQuery
    {
        public List<Animal> ZooAnimals { get; set; }
        public AdvancedAnimalQuery(List<Animal> animals)
        {
            ZooAnimals = animals;
        }


        #region AnimalsGroupByType
        public void ShowAnimalsGroupByType()
        {
            Console.WriteLine();
            Console.WriteLine("Animals group by type:");

            foreach (var g in GetAnimalsGroupByType())
            {
                Console.WriteLine($"Group: {g.Key}");

                foreach (var a in g)
                {
                    Console.WriteLine(a);
                }
            }
            Console.WriteLine();
        }

        private IEnumerable<IGrouping<Type, Animal>> GetAnimalsGroupByType()
        {
            return ZooAnimals
                .ToLookup(a => a.GetType());
        }
        #endregion


        #region AnimalsWithState
        public void ShowAnimalsWithState(Animal.State state)
        {
            Console.WriteLine();
            Console.WriteLine($"Animals with state {state}:");
            foreach (var a in GetAnimalsWithState(state))
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetAnimalsWithState(Animal.State state)
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == state);
        }
        #endregion


        #region SickTigers
        public void ShowSickTigers()
        {
            Console.WriteLine();
            Console.WriteLine($"Sick Tigers:");
            foreach (var a in GetSickTigers())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetSickTigers()
        {
            return ZooAnimals
                .Where(a => a is Tiger && a.StateOfAnimal == Animal.State.SICK);
        }
        #endregion


        #region AnimalByAlias
        public void ShowAnimalByAlias(string alias)
        {
            Console.WriteLine();
            Console.WriteLine($"Animal with alias {alias}:");
            Console.WriteLine(GetAnimalByAlias(alias));
            Console.WriteLine();
        }

        private Animal GetAnimalByAlias(string alias)
        {
            return ZooAnimals
                .Where(a => a is Elephant && a.Alias == alias)
                .FirstOrDefault();
        }
        #endregion


        #region HungryAliases
        public void ShowHungryAliases()
        {
            Console.WriteLine();
            Console.WriteLine($"Hungry aliases:");
            foreach (var a in GetHungryAliases())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<string> GetHungryAliases()
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == Animal.State.HUNGRY)
                .Select(a => a.Alias);
        }
        #endregion


        #region StrongestAnimalInType
        public void ShowStrongestAnimalInType()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest animal in type:");
            foreach (var a in GetStrongestAnimalInType())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetStrongestAnimalInType()
        {
            return GetAnimalsGroupByType()
                .Select(g => g.OrderByDescending(a => a.Health)
                .FirstOrDefault());
        }
        #endregion


        #region CountDeadGroupByType
        public void ShowCountDeadGroupByType()
        {
            Console.WriteLine();
            Console.WriteLine($"Count dead group by type:");
            foreach (var d in GetCountDeadGroupByType())
            {
                Console.WriteLine($"{d.Key} - {d.Value}");
            }
            Console.WriteLine();
        }

        private Dictionary<Type, int> GetCountDeadGroupByType()
        {
            return GetAnimalsGroupByType()
                .ToDictionary(g => g.Key, g => g.Count(a => a.StateOfAnimal == Animal.State.DEAD));
        }
        #endregion


        #region WolvesAndBearsByHealthMore3
        public void ShowWolvesAndBearsByHealthMore3()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest animal in type:");
            foreach (var a in GetWolvesAndBearsByHealthMore3())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetWolvesAndBearsByHealthMore3()
        {
            return ZooAnimals
                .Where(a => (a is Wolf || a is Bear) && a.Health > 3);
        }
        #endregion


        #region StrongestAndWeakest
        public void ShowStrongestAndWeakest()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest and weakest animal:");
            Animal strongest;
            Animal weakest;
            (strongest, weakest) = GetStrongestAndWeakest();
            Console.WriteLine($"Strongest: {strongest}");
            Console.WriteLine($"Weakest: {weakest}");
            Console.WriteLine();
        }

        private (Animal, Animal) GetStrongestAndWeakest()
        {
            return (ZooAnimals
                .OrderBy(a=>a.Health)
                .FirstOrDefault(),
                ZooAnimals
                .OrderBy(a => a.Health)
                .LastOrDefault());
        }
        #endregion


        #region AverageHealth
        public void ShowAverageHealth()
        {
            Console.WriteLine();
            Console.WriteLine($"Average animal health:");
            Console.WriteLine(GetAverageHealth());
            Console.WriteLine();
        }

        private int GetAverageHealth()
        {
            return Convert.ToInt32
                (ZooAnimals.Average(a => a.Health));
        }
        #endregion

    }
}
