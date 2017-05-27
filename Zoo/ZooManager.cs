using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Timers;

namespace Zoo
{
    class ZooManager
    {
        public ZooAction ZooAction { get; set; }
        public List<Animal> AllAnimals { get; set; }
        public ZooView ViewConsole { get; set; }
        public readonly List<Type> AnimalCreatorTypes;
        private Timer _timer;

        private List<AnimalCreator> _creators;

        private static Random _random = new Random();

        public ZooManager()
        {
            AllAnimals = new List<Animal>();
            AnimalCreatorTypes = new List<Type>()
            {
                typeof(BearCreator),
                typeof(ElephantCreator) ,
                typeof(FoxCreator) ,
                typeof(LionCreator) ,
                typeof(TigerCreator) ,
                typeof(WolfCreator)
            };

            ViewConsole = new ZooView(AllAnimals, AnimalCreatorTypes);

            _creators = new List<AnimalCreator>()
            {
                new BearCreator(),
                new ElephantCreator(),
                new FoxCreator(),
                new LionCreator(),
                new TigerCreator(),
                new WolfCreator()
            };
        }

        public void SetAnimalAction(ZooAction a)
        {
            ZooAction = a;
        }

        public void RunAction()
        {
            ZooAction?.Execute();
        }

        public void OpenZoo()
        {
            AllAnimals = ViewConsole.GetOriginAnimals();
            ProccessZooLife();
        }

        private void ProccessZooLife()
        {
            _timer = new System.Timers.Timer(5000);
            
            ViewConsole.ShowQueriesHelp();
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += ZooLoopCallback;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Start();
            while(_timer.Enabled)
            {
                string s = Console.ReadLine();
                if (s.ToLower() == ViewConsole.InputToHelp)
                {
                    ViewConsole.ShowQueriesHelp();
                }
                else if (s.ToLower() == ViewConsole.InputToShowAnimals)
                {
                    ViewConsole.ShowAnimals();
                }
                else
                {
                    ViewConsole.ShowQuery(s);
                }
            }
        }

        private void ZooLoopCallback(object sender, ElapsedEventArgs e)
        {
            var liveAnimals = AllAnimals.Where(a => a.StateOfAnimal != Animal.State.DEAD).ToList();
            Animal randomAnimal = liveAnimals[_random.Next(liveAnimals.Count)];

            LifeTickAnimalAction lifeAction = new LifeTickAnimalAction(randomAnimal);
            lifeAction.Execute();

            if (AllAnimals.Count(a => a.StateOfAnimal == Animal.State.DEAD) == AllAnimals.Count)
            {
                _timer.Stop();
            }
        }
    }
}
