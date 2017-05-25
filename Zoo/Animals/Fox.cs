using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Fox : Animal
    {
        public Fox()
            : base(3)
        {
            Health = MaxHealth;
        }
    }
}
