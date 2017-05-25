using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class CureAnimalAction : AnimalAction
    {
        public CureAnimalAction()
        {

        }
        public CureAnimalAction(Animal a) : base(a)
        {
        }

        public override void Execute()
        {
            CurrentAnimal.Cure();
        }

        public override string GetActionHelp()
        {
            return "Cure animal: (name)";
        }
    }
}
