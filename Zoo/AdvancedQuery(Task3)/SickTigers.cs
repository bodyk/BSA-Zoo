using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class SickTigers : BaseQuery
    {
        public SickTigers(List<Animal> animals) 
            : base(animals, 7, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Sick Tigers:");
            foreach (var a in GetQueryResult())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        public IEnumerable<Animal> GetQueryResult()
        {
            return ZooAnimals
                .Where(a => a is Tiger && a.StateOfAnimal == Animal.State.SICK);
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
