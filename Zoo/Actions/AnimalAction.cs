using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    abstract class AnimalAction: BaseAction
    {
        public AnimalAction()
        {

        }
        public AnimalAction(Animal a)
        {
            CurrentAnimal = a;
        }
    }
}
