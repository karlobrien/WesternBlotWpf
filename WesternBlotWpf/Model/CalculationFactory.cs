using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf.Model
{
    public class CalculationFactory
    {
        public IBlotParts CreateFormula(string gelType, IUserInput userInput)
        {
            switch (gelType)
            {
                case "Stacking":
                    return new BlotParts();
                case "Separation":
                    var separationGel = new SeparationGelCalculate();
                    return separationGel.CreateBlotParts(userInput);
                default:
                    throw new Exception("No implementation of this type");
            }
        }
    }
}
