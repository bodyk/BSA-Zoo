using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class WolfCreator : AnimalCreator
    {
        public override Animal GetAnimal()
        {
            return new Wolf();
        }
    }
}
