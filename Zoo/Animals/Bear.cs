using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Bear : Animal
    {
        public Bear()
            :base(6)
        {
            Health = MaxHealth;
        }
    }
}
