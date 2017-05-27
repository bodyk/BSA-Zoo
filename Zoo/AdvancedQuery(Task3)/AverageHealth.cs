using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class AverageHealth : BaseQuery
    {
        public AverageHealth(List<Animal> animals) 
            : base(animals, 4, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Average animal health:");
            Console.WriteLine(GetQueryResult());
            Console.WriteLine();
        }

        public int GetQueryResult()
        {
            return Convert.ToInt32
                (ZooAnimals.Average(a => a.Health));
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
