using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf.Model
{
    public class SeparationGelCalculate : AbstractGelCalculation
    {
        private BlotParts _blotParts;

        public override BlotParts CreateBlotParts(IUserInput userInput)
        {
            _blotParts = new BlotParts();
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
                result = (0.25 * percentGel) * numGel;
            }
            else
            {
                var temp = (0.25 * percentGel) * numGel;
                var temp2 = (temp / 100) * 33.3;
                result = temp + temp2;
            }

            return result;
        }

        private double CalculateDdH20(double numGel)
        {
            var result = (7.35*numGel) - _blotParts.Acrylamide;
            return result;
        }

        private double CalculateTris1(double numGel)
        {
            var result = 2.5 * numGel;
            return result;
        }

        private double CalculateSds(double numGel)
        {
            var result = 100 * numGel;
            return result;
        }

        private double CalculateAps(double numGel)
        {
            var result = 50 * numGel;
            return result;
        }

        private double CalculateTemd(double numGel)
        {
            var result = 5 * numGel;
            return result;
        }

        private double CalculateTotalVolume(double numGel)
        {
            var result = _blotParts.Dh20 + _blotParts.Acrylamide + _blotParts.Tris + (0.155 * numGel);
            return result;
        }

    }
}
