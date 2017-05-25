using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    abstract class Animal
    {
        public enum State
        {
            SATED,
            HUNGRY,
            SICK,
            DEAD
        }

        public byte Health { get; set; }
        public State StateOfAnimal { get; set; }
        public string Alias { get; set; }
        protected readonly byte MaxHealth;

        public Animal(byte maxHealth)
        {
            MaxHealth = maxHealth;
            StateOfAnimal = State.SATED;
        }

        public void Feed()
        {
            switch (StateOfAnimal)
            {
                case State.HUNGRY:
                    StateOfAnimal = State.SATED;
                    break;
                case State.SICK:
                    StateOfAnimal = State.HUNGRY;
                    break;
                default:
                    break;
            }
        }

        public void LifeTickExecute()
        {
            switch (StateOfAnimal)
            {
                case State.SATED:
                    StateOfAnimal = State.HUNGRY;
                    break;
                case State.HUNGRY:
                    StateOfAnimal = State.SICK;
                    break;
                case State.SICK:
                    Infect();
                    break;
                case State.DEAD:
                    break;
                default:
                    break;
            }
        }

        public void Infect()
        {
            if (Health != 0)
            {
                --Health;
            }

            if (Health == 0)
            {
                StateOfAnimal = State.DEAD;
            }
        }

        public void Cure()
        {
            if (Health + 1 <= MaxHealth)
                ++Health;
        }

        public override string ToString()
        {
            return string.Format("{0, -10}{1, -20}{2, -10}{3, -10}", this.GetType().Name, Alias, Health, StateOfAnimal);
        }
    }
}
