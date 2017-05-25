using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Zoo
{
    class ZooManager
    {
        public ZooAction ZooAction { get; set; }
        public List<Animal> LiveAnimals { get; set; }
        public List<Animal> DeadAnimals { get; set; }
        public ZooView ViewConsole { get; set; }
        public readonly List<Type> AnimalCreatorTypes;

        private List<AnimalCreator> _creators;

        private static Random _random = new Random();

        public ZooManager()
        {
            LiveAnimals = new List<Animal>();
            DeadAnimals = new List<Animal>();
            AnimalCreatorTypes = new List<Type>()
            {
                typeof(BearCreator),
                typeof(ElephantCreator) ,
                typeof(FoxCreator) ,
                typeof(LionCreator) ,
                typeof(TigerCreator) ,
                typeof(WolfCreator)
            };

            ViewConsole = new ZooView(LiveAnimals, AnimalCreatorTypes);

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
            LiveAnimals = ViewConsole.GetOriginAnimals();

            ProccessZooLife();
        }

        private void ProccessZooLife()
        {
            var autoEvent = new AutoResetEvent(false);
            Timer t = new Timer(ZooLoopCallback, autoEvent, 0, 5000);
            autoEvent.WaitOne();
            t.Dispose();
            ViewConsole.ShowGameOver();
        }

        private void ZooLoopCallback(object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            
            Animal randomAnimal = LiveAnimals[_random.Next(LiveAnimals.Count)];

            LifeTickAnimalAction lifeAction = new LifeTickAnimalAction(randomAnimal);
            lifeAction.Execute();

            if (randomAnimal.StateOfAnimal == Animal.State.DEAD)
            {
                DeadAnimals.Add(randomAnimal);
                LiveAnimals.Remove(randomAnimal);
            }
            
            ViewConsole.ClearScreen();
            ViewConsole.ShowAnimals(LiveAnimals, DeadAnimals);

            if (LiveAnimals.Count == 0)
            {
                autoEvent.Set();
            }

        }
    }
}
