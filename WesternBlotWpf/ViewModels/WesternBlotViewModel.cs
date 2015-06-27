using System;
using Caliburn.Micro;
using WesternBlotWpf.Model;

namespace WesternBlotWpf.ViewModels
{
    public class WesternBlotViewModel : Screen
    {
        public CalculateModel CalculateTheModel { get; private set; }
        public WesternBlotViewModel(CalculateModel calculateModel)
        {
            CalculateTheModel = calculateModel;
        }

        private int _numberOfGelsInput;
        public int NumberOfGelsInput
        {
            get {  return _numberOfGelsInput;}
            set
            {
                if (_numberOfGelsInput == value)
                    return;
                _numberOfGelsInput = value;
                NotifyOfPropertyChange(() => CanCalculate);
                NotifyOfPropertyChange("Dh20Separation");
                NotifyOfPropertyChange("AcrylamideSeparation");
                NotifyOfPropertyChange("Tris1Separation");
                NotifyOfPropertyChange("SdsSeparation");
                NotifyOfPropertyChange("ApsSeparation");
                NotifyOfPropertyChange("TemdSeparation");
                NotifyOfPropertyChange("TotalVolumeSeparation");
            }
        }

        private double _gelPercentageInput;
        public double GelPercentageInput
        {
            get { return _gelPercentageInput; }
            set
            {
                if (_gelPercentageInput == value)
                    return;
                _gelPercentageInput = value;
                NotifyOfPropertyChange(() => CanCalculate);
                NotifyOfPropertyChange("Dh20Separation");
                NotifyOfPropertyChange("AcrylamideSeparation");
                NotifyOfPropertyChange("Tris1Separation");
                NotifyOfPropertyChange("SdsSeparation");
                NotifyOfPropertyChange("ApsSeparation");
                NotifyOfPropertyChange("TemdSeparation");
                NotifyOfPropertyChange("TotalVolumeSeparation");
            }
        }

        private double _percentArcylamideInput;

        public double PercentArcylamideInput
        {
            get {  return _percentArcylamideInput; }
            set
            {
                if (_percentArcylamideInput == value)
                    return;
                _percentArcylamideInput = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange("Dh20Separation");
                NotifyOfPropertyChange("AcrylamideSeparation");
                NotifyOfPropertyChange("Tris1Separation");
                NotifyOfPropertyChange("SdsSeparation");
                NotifyOfPropertyChange("ApsSeparation");
                NotifyOfPropertyChange("TemdSeparation");
                NotifyOfPropertyChange("TotalVolumeSeparation");
            }
        }

        private double _dH20Separation;
        public double Dh20Separation
        {
            get
            {
                _dH20Separation = (7.35 * _numberOfGelsInput) - AcrylamideSeparation;
                return _dH20Separation;
            }
            set
            {
                if (Math.Abs(_dH20Separation - value) < 0)
                    return;
                NotifyOfPropertyChange();
            }
        }

        private double CalculateAcryLamideForSeparation()
        {
            double result;

            if (Math.Abs(_percentArcylamideInput - 40) < 0)
            {
                result = (0.25 * _gelPercentageInput) * _numberOfGelsInput;
            }
            else
            {
                var temp = (0.25 * _gelPercentageInput) * _numberOfGelsInput;
                var temp2 = (temp / 100) * 33.3;
                result = temp + temp2;
            }

            return result;
        }

        private double _acrylamideSeparation;
        public double AcrylamideSeparation
        {
            get
            {
                _acrylamideSeparation = CalculateAcryLamideForSeparation();
                return _acrylamideSeparation;
            }
            set
            {
                if (Math.Abs(_acrylamideSeparation - value) < 0)
                    return;
                _acrylamideSeparation = value;
                NotifyOfPropertyChange();
            }
        }

        private double _tris2;
        public double Tris2
        {
            get
            {
                
                return _tris2;
            }
            set
            {
                if (Math.Abs(_tris2 - value) < 0)
                    return;
                _tris2 = value;
                NotifyOfPropertyChange();
            }
        }

        private double _tris1Separation;
        public double Tris1Separation
        {
            get
            {
                _tris1Separation = 2.5 * _numberOfGelsInput;
                return _tris1Separation;
            }
            set
            {
                if (Math.Abs(_tris1Separation - value) < 0)
                    return;
                _tris1Separation = value;
                NotifyOfPropertyChange();
            }
        }

        private double _sdsSeparation;
        public double SdsSeparation
        {
            get
            {
                _sdsSeparation = 100 * _numberOfGelsInput;
                return _sdsSeparation;
            }
            set
            {
                if (Math.Abs(_sdsSeparation - value) < 0)
                    return;
                _sdsSeparation = value;
                NotifyOfPropertyChange();
            }
        }

        private double _apsSeparation;
        public double ApsSeparation
        {
            get
            {
                _apsSeparation = 50 * _numberOfGelsInput;
                return _apsSeparation;
            }
            set
            {
                if (Math.Abs(_apsSeparation - value) < 0)
                    return;
                _apsSeparation = value;
                NotifyOfPropertyChange();
            }
        }

        private double _temedSeparation;
        public double TemdSeparation
        {
            get
            {
                _temedSeparation = 5 * _numberOfGelsInput;
                return _temedSeparation;
            }
            set
            {
                if (Math.Abs(_temedSeparation - value) < 0)
                    return;
                _temedSeparation = value;
                NotifyOfPropertyChange();
            }
        }

        private double _totalVolumeSeparation;
        public double TotalVolumeSeparation
        {
            get
            {
                _totalVolumeSeparation = _dH20Separation + _acrylamideSeparation + _tris1Separation + (0.155 * _numberOfGelsInput);
                return _totalVolumeSeparation;
            }
            set
            {
                if (Math.Abs(_totalVolumeSeparation - value) < 0)
                    return;
                _totalVolumeSeparation = value;
                NotifyOfPropertyChange();
            }
        }










        public void Calculate()
        {
            SeparationGel = CalculateTheModel.CreateBlotParts(NumberOfGelsInput, GelPercentageInput, PercentArcylamideInput);
        }

        public bool CanCalculate
        {
            get
            {
                return _numberOfGelsInput > 0 && (_gelPercentageInput > 0 && _gelPercentageInput < 22);
            }           
        }



        private BlotParts _separationGel;
        public BlotParts SeparationGel
        {
            get { return _separationGel; }
            set
            {
                if (_separationGel == value)
                    return;
                _separationGel = value;
                NotifyOfPropertyChange();
            }
        }

        private BlotParts _stackingGel;
        public BlotParts StackingGel
        {
            get { return _stackingGel; }
            set
            {
                if (_stackingGel == value)
                    return;
                _stackingGel = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
