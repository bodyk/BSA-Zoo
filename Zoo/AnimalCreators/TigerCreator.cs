using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class TigerCreator: AnimalCreator
    {
        public override Animal GetAnimal()
        {
            return new Tiger();
        }
    }
}
