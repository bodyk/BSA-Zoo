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

        public IEnumerable<IGrouping<Type, Animal>> GetAnimalsGroupByType()
        {
            return ZooAnimals
                .ToLookup(a => a.GetType());
        }

        public IEnumerable<Animal> GetAnimalsWithState(Animal.State state)
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == state);
        }

        public IEnumerable<Animal> GetSickTigers()
        {
            return ZooAnimals
                .Where(a => a is Tiger && a.StateOfAnimal == Animal.State.SICK);
        }

        public Animal GetAnimalByAlias(string alias)
        {
            return ZooAnimals
                .Where(a => a is Elephant && a.Alias == alias)
                .FirstOrDefault();
        }

        public IEnumerable<string> GetHungryAliases()
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == Animal.State.HUNGRY)
                .Select(a => a.Alias);
        }

        public IEnumerable<Animal> GetStrongestAnimalInType()
        {
            return GetAnimalsGroupByType()
                .Select(g => g.OrderByDescending(a => a.Health)
                .FirstOrDefault());
        }

        public Dictionary<Type, int> GetCountDeadGroupByType()
        {
            return GetAnimalsGroupByType()
                .ToDictionary(g => g.Key, g => g.Count(a => a.StateOfAnimal == Animal.State.DEAD));
        }

        public IEnumerable<Animal> GetWolvesAndBearsByHealthMore3()
        {
            return ZooAnimals
                .Where(a => (a is Wolf || a is Bear) && a.Health > 3);
        }

        public (Animal, Animal) GetStrongestAndWeakest()
        {
            return (ZooAnimals
                .OrderBy(a=>a.Health)
                .FirstOrDefault(),
                ZooAnimals
                .OrderBy(a => a.Health)
                .LastOrDefault());
        }

        public int GetAverageHealth()
        {
            return Convert.ToInt32
                (ZooAnimals.Average(a => a.Health));
        }

    }
}
