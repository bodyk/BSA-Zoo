using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Tiger : Animal
    {
        public Tiger()
            : base(4)
        {
            Health = MaxHealth;
        }
    }
}
