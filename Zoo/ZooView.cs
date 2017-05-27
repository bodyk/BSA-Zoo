using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zoo.AdvancedQuery;
namespace Zoo
{
    class ZooView
    {
        private List<Type> _animalCreatorTypes;

        public List<Animal> ZooAnimals { get; set; }
        public List<BaseAction> ZooActions { get; set; }

        public string InputToStart { get { return "open"; }}
        public string InputToHelp { get { return "help"; } }
        public string InputToShowAnimals { get { return "show"; } }
        private const string _sDelimiter = "\n-----------------------------------------------------\n";
        private const string _sAnimalsInZoo = "Animals in Zoo:\n";
        private const string _sInputCommandHelp = "Separate parameters with space(Example - '1 alias'):\n";
        private const string _sAnimalTemplate = "{0, -10}{1, -20}{2, -10}{3, -10}";

        public List<BaseQuery> QueriesInfo { get; set; }

        public ZooView(List<Animal> animals)
        {
            ZooAnimals = animals;
            ZooActions = new List<BaseAction>() { new AddAnimalAction(), new CureAnimalAction(), new DeleteAnimalAction(), new FeedAnimalAction()};
            QueriesInfo = new List<BaseQuery>
            {
                new ElephantByAlias(ZooAnimals),
                new AnimalsGroupByType(ZooAnimals),
                new AnimalsWithState(ZooAnimals),
                new AverageHealth(ZooAnimals),
                new CountDeadGroupByType(ZooAnimals),
                new HungryAliases(ZooAnimals),
                new SickTigers(ZooAnimals),
                new StrongestAndWeakest(ZooAnimals),
                new StrongestAnimalInType(ZooAnimals),
                new WolvesAndBearsByHealthMore3(ZooAnimals)
            };
        }

        public ZooView(List<Animal> liveAnimals, List<Type> animalCreatorTypes) : this(liveAnimals)
        {
            this._animalCreatorTypes = animalCreatorTypes;
        }

        public void ShowStartHelp()
        {
            string sHelp = $"Add animals to open zoo.\nType '{InputToStart}' to finish animal initialization and open zoo";
            ShowAnimalTypesInfo();
            Console.WriteLine(sHelp);
            Console.WriteLine(_sInputCommandHelp);
            Console.WriteLine(_sDelimiter);
        }

        public void ShowQuery(string sQuery)
        {
            var arrUserInput = sQuery.Split(' ');

            try
            {
                var qClass = QueriesInfo.Where(q => q.nCommandNumber == Convert.ToInt32(arrUserInput[0])).FirstOrDefault();

                if (qClass?.bNeedParam != true)
                {
                    qClass?.ShowQueryResult();
                }
                else
                {
                    qClass?.ShowQueryResult(arrUserInput[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowQueriesHelp()
        {
            Console.WriteLine(_sDelimiter);
            Console.WriteLine($"Type '{InputToHelp}' to show help about queries");
            Console.WriteLine($"Type '{InputToShowAnimals}' to show all animals");
            Console.WriteLine(_sInputCommandHelp);
            Console.WriteLine("Possible animal states:");
            foreach (var state in Enum.GetValues(typeof(Animal.State)))
            {
                Console.WriteLine(state);
            }

            Console.WriteLine(_sDelimiter);
            foreach (var info in QueriesInfo)
            {
                Console.WriteLine(info);
            }

            Console.WriteLine(_sDelimiter);

        }

        public void ShowAnimalTypesInfo()
        {
            for (int i = 0; i < _animalCreatorTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_animalCreatorTypes[i].Name}");
            }
        }

        /*public void ShowUsualHelp()
        {
            foreach (var action in ZooActions)
            {
                Console.WriteLine(action.GetActionHelp());
            }
        }*/

        public void ShowInvalidInputError()
        {
            Console.WriteLine("Invalid user input!!!");
        }

        public void ShowAnimals()
        {
            Console.WriteLine(_sAnimalsInZoo);
            Console.WriteLine(string.Format(_sAnimalTemplate, "Type", "Alias", "Health", "State"));

            Console.WriteLine();
            ShowAnimalsInfo(ZooAnimals);
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
                ShowStartHelp();
                if (sUserInput.ToLower() == InputToStart)
                {
                    if (ZooAnimals.Count == 0)
                    {
                        ShowInvalidInputError();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (sUserInput.ToLower() == InputToHelp)
                {
                    ShowQueriesHelp();
                }

                var arrUserInput = sUserInput.Split(' ');

                if (arrUserInput.Length == nCurrentParamCount)
                {
                    int nCommandNumber = Convert.ToInt32(arrUserInput[0]);
                    Animal curAnimal;

                    if (nCommandNumber <= _animalCreatorTypes.Count)
                    {
                        AnimalCreator curAnimalCreator = (AnimalCreator)Activator.CreateInstance(_animalCreatorTypes[nCommandNumber - 1]);
                        curAnimal = curAnimalCreator.GetAnimal();
                        curAnimal.Alias = arrUserInput[1];
                        ZooAnimals.Add(curAnimal);

                        ShowAnimals();
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
            ClearScreen();

            return ZooAnimals;
        }

        public void ShowGameOver()
        {
            Console.WriteLine("GAME OVER");
        }
    }
}
