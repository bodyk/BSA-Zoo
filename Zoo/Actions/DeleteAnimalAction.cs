using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class DeleteAnimalAction : ZooAction
    {
        public DeleteAnimalAction()
        {

        }
        public DeleteAnimalAction(List<Animal> animals, Animal curAnimal) : base(animals, curAnimal)
        {
        }

        public override void Execute()
        {
            Animals.Remove(CurrentAnimal);
        }

        public override string GetActionHelp()
        {
            return "Delete animal: (name)";
        }
    }
}
