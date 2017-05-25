using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Lion: Animal
    {
        public Lion()
            : base(5)
        {
            Health = MaxHealth;
        } 
    }
}
