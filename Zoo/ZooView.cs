using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Zoo
{
    class ZooView
    {
        private List<Type> _animalCreatorTypes;

        public List<Animal> ZooAnimals { get; set; }
        public List<BaseAction> ZooActions { get; set; }

        private const string _inputToStart = "open";
        private const string _sDelimiter = "\n-----------------------------------------------------\n";
        private const string _sAnimalsInZoo = "Animals in Zoo:\n";
        private const string _sAnimalTemplate = "{0, -10}{1, -20}{2, -10}{3, -10}";

        private string _help = "help";
        public string InputHelp { get { return _help; }}

        private string _clear = "clear";
        public string InputClear { get { return _clear; } }

        private string _showAnimals = "sa";
        public string InputShowAnimals { get { return _showAnimals; } }

        private string _q1 = "1";
        public string InputQuery1 { get { return _q1; } }

        private string _q2 = "2";
        public string InputQuery2 { get { return _q2; } }

        private string _q3 = "3";
        public string InputQuery3 { get { return _q3; } }

        private string _q4 = "4";
        public string InputQuery4 { get { return _q4; } }

        private string _q5 = "5";
        public string InputQuery5 { get { return _q5; } }

        private string _q6 = "6";
        public string InputQuery6 { get { return _q6; } }

        private string _q7 = "7";
        public string InputQuery7 { get { return _q7; } }

        private string _q8 = "8";
        public string InputQuery8 { get { return _q8; } }

        private string _q9 = "9";
        public string InputQuery9 { get { return _q9; } }

        private string _q10 = "10";
        public string InputQuery10 { get { return _q10; } }

        public List<Tuple<string, Action, string>> HelpFunctions { get; set; }


        #region AnimalsGroupByType
        public void ShowAnimalsGroupByType()
        {
            Console.WriteLine();
            Console.WriteLine("Animals group by type:");

            foreach (var g in GetAnimalsGroupByType())
            {
                Console.WriteLine($"Group: {g.Key}");

                foreach (var a in g)
                {
                    Console.WriteLine(a);
                }
            }
            Console.WriteLine();
        }

        private IEnumerable<IGrouping<Type, Animal>> GetAnimalsGroupByType()
        {
            return ZooAnimals
                .ToLookup(a => a.GetType());
        }
        #endregion


        #region AnimalsWithState
        public void ShowAnimalsWithState(Animal.State state)
        {
            Console.WriteLine();
            Console.WriteLine($"Animals with state {state}:");
            foreach (var a in GetAnimalsWithState(state))
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetAnimalsWithState(Animal.State state)
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == state);
        }
        #endregion


        #region SickTigers
        public void ShowSickTigers()
        {
            Console.WriteLine();
            Console.WriteLine($"Sick Tigers:");
            foreach (var a in GetSickTigers())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetSickTigers()
        {
            return ZooAnimals
                .Where(a => a is Tiger && a.StateOfAnimal == Animal.State.SICK);
        }
        #endregion


        #region AnimalByAlias
        public void ShowAnimalByAlias(string alias)
        {
            Console.WriteLine();
            Console.WriteLine($"Animal with alias {alias}:");
            Console.WriteLine(GetAnimalByAlias(alias));
            Console.WriteLine();
        }

        private Animal GetAnimalByAlias(string alias)
        {
            return ZooAnimals
                .Where(a => a is Elephant && a.Alias == alias)
                .FirstOrDefault();
        }
        #endregion


        #region HungryAliases
        public void ShowHungryAliases()
        {
            Console.WriteLine();
            Console.WriteLine($"Hungry aliases:");
            foreach (var a in GetHungryAliases())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<string> GetHungryAliases()
        {
            return ZooAnimals
                .Where(a => a.StateOfAnimal == Animal.State.HUNGRY)
                .Select(a => a.Alias);
        }
        #endregion


        #region StrongestAnimalInType
        public void ShowStrongestAnimalInType()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest animal in type:");
            foreach (var a in GetStrongestAnimalInType())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetStrongestAnimalInType()
        {
            return GetAnimalsGroupByType()
                .Select(g => g.OrderByDescending(a => a.Health)
                .FirstOrDefault());
        }
        #endregion


        #region CountDeadGroupByType
        public void ShowCountDeadGroupByType()
        {
            Console.WriteLine();
            Console.WriteLine($"Count dead group by type:");
            foreach (var d in GetCountDeadGroupByType())
            {
                Console.WriteLine($"{d.Key} - {d.Value}");
            }
            Console.WriteLine();
        }

        private Dictionary<Type, int> GetCountDeadGroupByType()
        {
            return GetAnimalsGroupByType()
                .ToDictionary(g => g.Key, g => g.Count(a => a.StateOfAnimal == Animal.State.DEAD));
        }
        #endregion


        #region WolvesAndBearsByHealthMore3
        public void ShowWolvesAndBearsByHealthMore3()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest animal in type:");
            foreach (var a in GetWolvesAndBearsByHealthMore3())
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
        }

        private IEnumerable<Animal> GetWolvesAndBearsByHealthMore3()
        {
            return ZooAnimals
                .Where(a => (a is Wolf || a is Bear) && a.Health > 3);
        }
        #endregion


        #region StrongestAndWeakest
        public void ShowStrongestAndWeakest()
        {
            Console.WriteLine();
            Console.WriteLine($"Strongest and weakest animal:");
            Animal strongest;
            Animal weakest;
            (strongest, weakest) = GetStrongestAndWeakest();
            Console.WriteLine($"Strongest: {strongest}");
            Console.WriteLine($"Weakest: {weakest}");
            Console.WriteLine();
        }

        private (Animal, Animal) GetStrongestAndWeakest()
        {
            return (ZooAnimals
                .OrderBy(a => a.Health)
                .FirstOrDefault(),
                ZooAnimals
                .OrderBy(a => a.Health)
                .LastOrDefault());
        }
        #endregion


        #region AverageHealth
        public void ShowAverageHealth()
        {
            Console.WriteLine();
            Console.WriteLine($"Average animal health:");
            Console.WriteLine(GetAverageHealth());
            Console.WriteLine();
        }

        private int GetAverageHealth()
        {
            return Convert.ToInt32
                (ZooAnimals.Average(a => a.Health));
        }
        #endregion



        public ZooView(List<Animal> animals)
        {
            ZooAnimals = animals;
            ZooActions = new List<BaseAction>() { new AddAnimalAction(), new CureAnimalAction(), new DeleteAnimalAction(), new FeedAnimalAction()};
            HelpFunctions = new List<Tuple<string, Action, string>>
            {
                Tuple.Create<string, Action, string>(InputHelp, ShowMainHelp, "ShowMainHelp"),
                Tuple.Create<string, Action, string>(InputClear, ClearScreen, "ClearScreen"),
                Tuple.Create<string, Action, string>(InputShowAnimals, ShowAnimals, "ShowAnimals"),
                Tuple.Create<string, Action, string>(InputQuery1, ShowAnimalsGroupByType, "ShowAnimalsGroupByType"),
                //{ InputQuery2, ShowAnimalsWithState},
                Tuple.Create<string, Action, string>(InputQuery3, ShowSickTigers, "ShowSickTigers"),
               // { InputQuery4, ShowAnimalByAlias},
                Tuple.Create<string, Action, string>(InputQuery5, ShowHungryAliases, "ShowHungryAliases"),
                Tuple.Create<string, Action, string>(InputQuery6, ShowStrongestAnimalInType, "ShowStrongestAnimalInType"),
                Tuple.Create<string, Action, string>(InputQuery7, ShowCountDeadGroupByType, "ShowCountDeadGroupByType"),
                Tuple.Create<string, Action, string>(InputQuery8, ShowWolvesAndBearsByHealthMore3, "ShowWolvesAndBearsByHealthMore3"),
                Tuple.Create<string, Action, string>(InputQuery9, ShowStrongestAndWeakest, "ShowStrongestAndWeakest"),
                Tuple.Create<string, Action, string>(InputQuery10, ShowAverageHealth, "ShowAverageHealth"),
            };
        }

        public ZooView(List<Animal> liveAnimals, List<Type> animalCreatorTypes) : this(liveAnimals)
        {
            this._animalCreatorTypes = animalCreatorTypes;
        }

        public void ShowStartHelp()
        {
            string sHelp = $"Add animals to open zoo.\nType '{_inputToStart}' to finish animal initialization and open zoo";
            ShowAnimalTypesInfo();
            Console.WriteLine(sHelp);
            Console.WriteLine(_sDelimiter);
        }

        public void ShowMainHelp()
        {
            Console.WriteLine(_sDelimiter);
            Console.WriteLine("Main Help:");
            Console.WriteLine($"{InputHelp} - show help info");
            Console.WriteLine($"{InputClear} - clear screen");
            Console.WriteLine($"{InputShowAnimals} - show animals in zoo");
            Console.WriteLine($"{InputQuery1} - {HelpFunctions[0].Item3}");
            Console.WriteLine($"{InputQuery2} - {HelpFunctions[1].Item3}");
            Console.WriteLine($"{InputQuery3} - {HelpFunctions[2].Item3}");
            Console.WriteLine($"{InputQuery4} - {HelpFunctions[3].Item3}");
            Console.WriteLine($"{InputQuery5} - {HelpFunctions[4].Item3}");
            Console.WriteLine($"{InputQuery6} - {HelpFunctions[5].Item3}");
            Console.WriteLine($"{InputQuery7} - {HelpFunctions[6].Item3}");
            Console.WriteLine($"{InputQuery8} - {HelpFunctions[7].Item3}");
            Console.WriteLine($"{InputQuery9} - {HelpFunctions[8].Item3}");
            Console.WriteLine($"{InputQuery10} - {HelpFunctions[9].Item3}");

            Console.WriteLine(_sDelimiter);

        }

        public void ShowAnimalTypesInfo()
        {
            for (int i = 0; i < _animalCreatorTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_animalCreatorTypes[i].Name}");
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

            return ZooAnimals;
        }

        public void ShowGameOver()
        {
            Console.WriteLine("GAME OVER");
        }
    }
}
