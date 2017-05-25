using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class AddAnimalAction : ZooAction
    {
        public AddAnimalAction()
        {

        }
        public AddAnimalAction(List<Animal> animals, Animal curAnimal) : base(animals, curAnimal)
        {
        }

        public override void Execute()
        {
            Animals.Add(CurrentAnimal);
        }

        public override string GetActionHelp()
        {
            return "Add animal: (name, animal type)";
        }
    }
}
