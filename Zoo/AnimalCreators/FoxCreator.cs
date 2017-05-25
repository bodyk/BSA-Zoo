using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class FoxCreator: AnimalCreator
    {
        public override Animal GetAnimal()
        {
            return new Fox();
        }
    }
}
