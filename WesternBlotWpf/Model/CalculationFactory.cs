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
            AbstractGelCalculation gelCalc;
            switch (gelType)
            {
                case "Stacking":
                    gelCalc = new StackingGelCalculate();
                    break;
                case "Separation":
                    gelCalc = new SeparationGelCalculate();
                    break;
                default:
                    throw new Exception("No implementation of this type");
            }
            return gelCalc.CreateBlotParts(userInput);
        }
    }
}
