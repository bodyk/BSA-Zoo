using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Wolf : Animal
    {
        public Wolf()
            : base(4)
        {
            Health = MaxHealth;
        }
    }
}
