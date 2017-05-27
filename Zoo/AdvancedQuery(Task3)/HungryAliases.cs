using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class HungryAliases : BaseQuery
    {
        public HungryAliases(List<Animal> animals) 
            : base(animals, 6, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Hungry aliases:");
            foreach (var a in GetQueryResult())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        public IEnumerable<string> GetQueryResult()
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == Animal.State.HUNGRY)
                .Select(a => a.Alias);
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
