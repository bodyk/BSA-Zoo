using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class AnimalsWithState : BaseQuery
    {
        public AnimalsWithState(List<Animal> animals) 
            : base(animals, 3, true)
        {
        }

        public override void ShowQueryResult(string state)
        {
            Console.WriteLine();
            Console.WriteLine($"Animals with state {state}:");
            foreach (var a in GetQueryResult((Animal.State)Enum.Parse(typeof(Animal.State), state.ToUpper())))
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        public IEnumerable<Animal> GetQueryResult(Animal.State state)
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == state);
        }

        public override void ShowQueryResult()
        {
            throw new NotImplementedException();
        }
    }
}
