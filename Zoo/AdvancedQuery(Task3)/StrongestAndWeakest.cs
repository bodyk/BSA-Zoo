using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    class StrongestAndWeakest : BaseQuery
    {
        public StrongestAndWeakest(List<Animal> animals) 
            : base(animals, 8, false)
        {
        }

        public override void ShowQueryResult()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest and weakest animal:");
            Animal strongest;
            Animal weakest;
            (strongest, weakest) = GetQueryResult();
            Console.WriteLine($"Strongest: {strongest}");
            Console.WriteLine($"Weakest: {weakest}");
            Console.WriteLine();
        }

        public (Animal, Animal) GetQueryResult()
        {
            return ZooAnimals
                .Aggregate((minA: ZooAnimals[0], maxA: ZooAnimals[0]),
                (acc, elem) =>
                    (acc.minA = acc.minA.Health > elem.Health && elem.StateOfAnimal != Animal.State.DEAD ? elem : acc.minA,
                        acc.maxA = acc.maxA.Health < elem.Health && elem.StateOfAnimal != Animal.State.DEAD ? elem : acc.maxA
                    ));
        }

        public override void ShowQueryResult(string param)
        {
            throw new NotImplementedException();
        }
    }
}
