﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf.Model
{
    public class CalculateModel
    {
        private BlotParts _blotParts;

        public BlotParts CreateBlotParts(double numGel, double percentGel, double percentArcy)
        {
            _blotParts = new BlotParts();
            _blotParts.Acrylamide = CalculateAcryLamide(numGel, percentGel, percentArcy);
            _blotParts.Dh20 = CalculateDdH20(numGel);
            _blotParts.Tris1 = CalculateTris1(numGel);
            _blotParts.Sds = CalculateSds(numGel);
            _blotParts.Aps = CalculateAps(numGel);
            _blotParts.Temd = CalculateTemd(numGel);
            _blotParts.TotalVolume = CalculateTotalVolume(numGel);

            return _blotParts;
        }

        private double CalculateAcryLamide(double numGel, double percentGel, double percentArcy)
        {
            double result;
            double temp;
            double temp2;

            if (Math.Abs(percentArcy - 40) < 0)
            {
                result = (0.25 * percentGel) * numGel;
            }
            else
            {
                temp = (0.25 * percentGel) * numGel;
                temp2 = (temp / 100) * 33.3;
                result = temp + temp2;
            }

            return result;
        }

        private double CalculateDdH20(Double numGel)
        {
            var result = (7.35*numGel) - _blotParts.Acrylamide;
            return result;
        }

        private double CalculateTris1(Double numGel)
        {
            var result = 2.5 * numGel;
            return result;
        }

        private double CalculateTris2(Double numGel)
        {
            var result = 0.0;
            return result;
        }

        private double CalculateSds(Double numGel)
        {
            var result = 100 * numGel;
            return result;
        }

        private double CalculateAps(Double numGel)
        {
            double result = 50 * numGel;
            return result;
        }

        private double CalculateTemd(Double numGel)
        {
            double result = 5 * numGel;
            return result;
        }

        private double CalculateTotalVolume(Double numGel)
        {
            double result = _blotParts.Dh20 + _blotParts.Acrylamide + _blotParts.Tris1 + (0.155 * numGel);
            return result;
        }

    }
}