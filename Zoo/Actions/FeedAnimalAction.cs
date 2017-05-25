using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class FeedAnimalAction : AnimalAction
    {
        public FeedAnimalAction()
        {

        }
        public FeedAnimalAction(Animal a) : base(a)
        {
        }

        public override void Execute()
        {
            CurrentAnimal.Feed();
        }

        public override string GetActionHelp()
        {
            return "Feed animal: (name)";
        }
    }
}
