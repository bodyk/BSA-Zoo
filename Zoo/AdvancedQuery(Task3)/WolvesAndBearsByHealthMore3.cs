using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class WolvesAndBearsByHealthMore3 : BaseQuery
    {
        public WolvesAndBearsByHealthMore3(List<Animal> animals) 
            : base(animals, 10, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest animal in type:");
            foreach (var a in GetQueryResult())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        public IEnumerable<Animal> GetQueryResult()
        {
            return ZooAnimals
                .Where(a => (a is Wolf || a is Bear) && a.Health > 3);
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
