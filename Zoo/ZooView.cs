using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    class ZooView
    {
        private List<Type> animalCreatorTypes;

        public List<Animal> LiveAnimals { get; set; }
        public List<BaseAction> ZooActions { get; set; }

        private const string _inputToStart = "open";
        private const string _sDelimiter = "\n-----------------------------------------------------\n";
        private const string _sAnimalsInZoo = "Animals in Zoo:\n";
        private const string _sAnimalTemplate = "{0, -10}{1, -20}{2, -10}{3, -10}";

        public ZooView(List<Animal> animals)
        {
            LiveAnimals = animals;
            ZooActions = new List<BaseAction>() { new AddAnimalAction(), new CureAnimalAction(), new DeleteAnimalAction(), new FeedAnimalAction()};
        }

        public ZooView(List<Animal> liveAnimals, List<Type> animalCreatorTypes) : this(liveAnimals)
        {
            this.animalCreatorTypes = animalCreatorTypes;
        }

        public void ShowStartHelp()
        {
            string sHelp = $"Add animals to open zoo.\nType '{_inputToStart}' to finish animal initialization and open zoo";
            ShowAnimalTypesInfo();
            Console.WriteLine(sHelp);
            Console.WriteLine(_sDelimiter);
        }

        public void ShowAnimalTypesInfo()
        {
            for (int i = 0; i < animalCreatorTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {animalCreatorTypes[i].Name}");
            }
        }

        public void ShowUsualHelp()
        {
            foreach (var action in ZooActions)
            {
                Console.WriteLine(action.GetActionHelp());
            }
        }

        public void ShowInvalidInputError()
        {
            Console.WriteLine("Invalid user input!!!");
        }

        public void ShowAnimals(List<Animal> liveAnimals, List<Animal> deadAnimals)
        {
            Console.WriteLine(_sAnimalsInZoo);
            Console.WriteLine(string.Format(_sAnimalTemplate, "Type", "Alias", "Health", "State"));

            Console.WriteLine();
            ShowAnimalsInfo(liveAnimals);
            ShowAnimalsInfo(deadAnimals);
            Console.WriteLine(_sDelimiter);
        }

        public void ShowAnimalsInfo(List<Animal> animals)
        {
            if (animals != null)
            {
                foreach (Animal animal in animals)
                {
                    ShowAnimal(animal);
                }
            }
        }

        public void ShowAnimal(Animal animal)
        {
            Console.WriteLine(string.Format(_sAnimalTemplate, animal.GetType().Name, animal.Alias, animal.Health, animal.StateOfAnimal));
        }

        public void ClearScreen()
        {
            Console.Clear();
            ShowStartHelp();
        }

        public List<Animal> GetOriginAnimals()
        {
            ShowStartHelp();
            string sUserInput = "";
            const int nCurrentParamCount = 2;

            do
            {
                sUserInput = Console.ReadLine();
                ClearScreen();
                if (sUserInput.ToLower() == _inputToStart)
                {
                    if (LiveAnimals.Count == 0)
                    {
                        ShowInvalidInputError();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                var arrUserInput = sUserInput.Split(' ');

                if (arrUserInput.Length == nCurrentParamCount)
                {
                    int nCommandNumber = Convert.ToInt32(arrUserInput[0]);
                    Animal curAnimal;

                    if (nCommandNumber <= animalCreatorTypes.Count)
                    {
                        AnimalCreator curAnimalCreator = (AnimalCreator)Activator.CreateInstance(animalCreatorTypes[nCommandNumber - 1]);
                        curAnimal = curAnimalCreator.GetAnimal();
                        curAnimal.Alias = arrUserInput[1];
                        LiveAnimals.Add(curAnimal);

                        ShowAnimals(LiveAnimals, null);
                    }
                    else
                    {
                        ShowInvalidInputError();
                    }
                }
                else
                {
                    ShowInvalidInputError();
                }
            } while (true);

            return LiveAnimals;
        }

        public void ShowGameOver()
        {
            Console.WriteLine("GAME OVER");
        }
    }
}
