using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class LionCreator: AnimalCreator
    {
        public override Animal GetAnimal()
        {
            return new Lion();
        }
    }
}
