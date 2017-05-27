using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class ElephantByAlias : BaseQuery
    {
        public ElephantByAlias(List<Animal> animals) 
            : base(animals, 1, true)
        {
        }

        public override void ShowQueryResult(string alias)
        {
            Console.WriteLine();
            Console.WriteLine($"Animal with alias {alias}:");
            Console.WriteLine(GetQueryResult(alias));
            Console.WriteLine();
        }

        public Animal GetQueryResult(string alias)
        {
            return ZooAnimals
                .Where(a => a is Elephant && a.Alias == alias)
                .FirstOrDefault();
        }

        public override void ShowQueryResult()
        {
            throw new NotImplementedException();
        }
    }
}
