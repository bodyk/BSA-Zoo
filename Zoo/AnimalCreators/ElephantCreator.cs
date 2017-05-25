using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class ElephantCreator : AnimalCreator
    {
        public override Animal GetAnimal()
        {
            return new Elephant();
        }
    }
}
