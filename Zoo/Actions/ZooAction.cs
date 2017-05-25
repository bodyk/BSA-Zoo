using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    abstract class ZooAction: BaseAction
    {
        protected List<Animal> Animals { get; set; }
        public ZooAction()
        {

        }
        public ZooAction(List<Animal> animals, Animal curAnimal)
        {
            Animals = animals;
            CurrentAnimal = curAnimal;
        }
    }
}
