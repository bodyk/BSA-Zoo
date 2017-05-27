using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class CountDeadGroupByType : BaseQuery
    {
        private AnimalsGroupByType _qGroup;
        public CountDeadGroupByType(List<Animal> animals) 
            : base(animals, 5, false)
        {
            _qGroup = new AnimalsGroupByType(animals);
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Count dead group by type:");
            foreach (var d in GetQueryResult())
            {
                Console.WriteLine($"{d.Key} - {d.Value}");
            }
            Console.WriteLine();
        }

        public Dictionary<Type, int> GetQueryResult()
        {
            return _qGroup.GetQueryResult()
                .ToDictionary(g => g.Key, g => g.Count(a => a.StateOfAnimal == Animal.State.DEAD));
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
