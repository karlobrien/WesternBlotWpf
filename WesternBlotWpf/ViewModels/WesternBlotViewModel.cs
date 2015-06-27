using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private int _numberOfGels;

        public int NumberOfGels
        {
            get {  return _numberOfGels;}
            set
            {
                if (_numberOfGels == value)
                    return;
                _numberOfGels = value;
                NotifyOfPropertyChange(() => CanCalculate);
            }
        }

        private double _gelPercentage;
        public double GelPercentage
        {
            get { return _gelPercentage; }
            set
            {
                if (_gelPercentage == value)
                    return;
                _gelPercentage = value;
                NotifyOfPropertyChange(() => CanCalculate);

            }
        }

        private double _arcylamide;

        public double Arcylamide
        {
            get {  return _arcylamide; }
            set
            {
                if (_arcylamide == value)
                    return;
                _arcylamide = value;
                NotifyOfPropertyChange();
            }
        }

        public WesternBlotViewModel()
        {
            NumberOfGels = 3;
            GelPercentage = 23;
            Arcylamide = 345;
        }

        public void Calculate()
        {
            SeparationGel = CalculateTheModel.CreateBlotParts(NumberOfGels, GelPercentage, Arcylamide);
        }

        public bool CanCalculate
        {
            get
            {
                return _numberOfGels > 0 && (_gelPercentage > 0 && _gelPercentage < 22);
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
