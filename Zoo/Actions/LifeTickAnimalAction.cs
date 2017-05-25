using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class LifeTickAnimalAction : AnimalAction
    {
        public LifeTickAnimalAction()
        {

        }

        public LifeTickAnimalAction(Animal a): base(a)
        {

        }
        public override void Execute()
        {
            CurrentAnimal.LifeTickExecute();
        }

        public override string GetActionHelp()
        {
            return "";
        }
    }
}
