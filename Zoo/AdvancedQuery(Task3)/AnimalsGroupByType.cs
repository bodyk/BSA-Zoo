using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class AnimalsGroupByType : BaseQuery
    {
        public AnimalsGroupByType(List<Animal> animals) 
            : base(animals, 2, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine("Animals group by type:");

            foreach (var g in GetQueryResult())
            {
                Console.WriteLine($"Group: {g.Key}");

                foreach (var a in g)
                {
                    Console.WriteLine(a);
                }
            }
            Console.WriteLine();
        }

        public IEnumerable<IGrouping<Type, Animal>> GetQueryResult()
        {
            return ZooAnimals
                .ToLookup(a => a.GetType());
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
