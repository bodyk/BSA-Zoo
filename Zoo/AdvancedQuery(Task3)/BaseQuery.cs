using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.AdvancedQuery
{
    abstract class BaseQuery
    {
        public List<Animal> ZooAnimals { get; set; }
        public readonly int nCommandNumber;
        public readonly bool bNeedParam;
        public readonly string sUserCommandHelp;
        public BaseQuery(List<Animal> animals, int nCommand, bool bUseParam)
        {
            ZooAnimals = animals;
            nCommandNumber = nCommand;
            bNeedParam = bUseParam;
            sUserCommandHelp = this.GetType().Name;
        }

        public override string ToString()
        {
            return string.Format("{0, -3} - {1, -30} - {2, -15} - {3, -7}", nCommandNumber, sUserCommandHelp, "(Need Parameter)", bNeedParam);;
        }

        public abstract void ShowQueryResult();
        public abstract void ShowQueryResult(string param);

    }
}
