using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf.Model
{
    public class StackingGelCalculate : AbstractGelCalculation
    {
        private IBlotParts _blotParts;

        public override IBlotParts CreateBlotParts(IUserInput userInput)
        {
            _blotParts = new BlotParts();
            _blotParts.GelName = "Stacking Gel";
            _blotParts.Acrylamide = CalculateAcryLamide(userInput.numGel, userInput.percentGel, userInput.percentArcy);
            _blotParts.Dh20 = CalculateDdH20(userInput.numGel);
            _blotParts.Tris = CalculateTris1(userInput.numGel);
            _blotParts.Sds = CalculateSds(userInput.numGel);
            _blotParts.Aps = CalculateAps(userInput.numGel);
            _blotParts.Temd = CalculateTemd(userInput.numGel);
            _blotParts.TotalVolume = CalculateTotalVolume(userInput.numGel);

            return _blotParts;
        }

        private double CalculateAcryLamide(double numGel, double percentGel, double percentArcy)
        {
            double result;

            if (Math.Abs(percentArcy - 40) == 0)
            {
                result = 0.36 *  numGel;
            }
            else
            {
                var temp = 0.36 * numGel;
                var temp2 = (temp / 100) * 33.3;
                result = temp + temp2;
            }

            return result;
        }

        private double CalculateDdH20(double numGel)
        {
            var result = (2.76 * numGel) - _blotParts.Acrylamide;
            return result;
        }

        private double CalculateTris1(double numGel)
        {
            var result = 0.9 * numGel;
            return result;
        }

        private double CalculateSds(double numGel)
        {
            var result = 36 * numGel;
            return result;
        }

        private double CalculateAps(double numGel)
        {
            var result = 18 * numGel;
            return result;
        }

        private double CalculateTemd(double numGel)
        {
            var result = 3.6 * numGel;
            return result;
        }

        private double CalculateTotalVolume(double numGel)
        {
            var result = _blotParts.Dh20 + _blotParts.Acrylamide + _blotParts.Tris + (0.0576 * numGel);
            return result;
        }
    }
}
