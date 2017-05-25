using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Elephant : Animal
    {
        public Elephant()
            : base(7)
        {
            Health = MaxHealth;
        }
    }
}
