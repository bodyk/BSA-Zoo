using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class StrongestAnimalInType : BaseQuery
    {
        private AnimalsGroupByType _qGroup;
        public StrongestAnimalInType(List<Animal> animals) 
            : base(animals, 9, false)
        {
            _qGroup = new AnimalsGroupByType(animals);
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
            return _qGroup.GetQueryResult()
                .Select(g => g.OrderByDescending(a => a.Health)
                .FirstOrDefault());
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
