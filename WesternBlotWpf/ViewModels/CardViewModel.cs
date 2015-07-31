using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using WesternBlotWpf.Model;

namespace WesternBlotWpf.ViewModels
{
    public class CardViewModel : Screen
    {
        private CalculationFactory _calculationFactory;

        public CardViewModel()
        {
            _calculationFactory = new CalculationFactory();

            IBlotParts separationResults = new BlotParts { GelName="Separation Gel" };
            IBlotParts stackResults = new BlotParts { GelName = "Stacking Gel" };

            BlotResults = new ObservableCollection<IBlotParts>();
            BlotResults.Add(separationResults);
            BlotResults.Add(stackResults);
        }

        private double _gelNumber;
        public double GelNumber 
        {
            get { return _gelNumber; }
            set
            {
                if (_gelNumber == value)
                    return;
                _gelNumber = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanCalculateWesternBlot);
            }
        }

        private double _gelPercent;
        public double GelPercent 
        {
            get { return _gelPercent; }
            set
            {
                if (_gelPercent == value)
                    return;
                _gelPercent = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanCalculateWesternBlot);
            }
        }

        public List<int> ArcyPercentItems
        {
            get
            {
                return new List<int> { 30, 40 }; 
            }
        }

        private int _selectedArcyPercent;
        public int SelectedArcyPercent 
        {
            get { return _selectedArcyPercent; }
            set
            {
                _selectedArcyPercent = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => CanCalculateWesternBlot);
            }
        }

        private ObservableCollection<IBlotParts> _blotParts;
        public ObservableCollection<IBlotParts> BlotResults
        {
            get { return _blotParts; }
            set
            {
                if (_blotParts == value)
                    return;
                _blotParts = value;
                NotifyOfPropertyChange();
            }
        }

        public void CalculateWesternBlot()
        {
            IUserInput userInput = new UserInput(GelNumber, GelPercent, SelectedArcyPercent);

            var blotForSeparation = _calculationFactory.CreateFormula("Separation", userInput);
            var blotForStacking = _calculationFactory.CreateFormula("Stacking", userInput);
            BlotResults[0] = blotForSeparation;
            BlotResults[1] = blotForStacking;
        }

        public bool CanCalculateWesternBlot
        {
            get
            {
                return ((GelNumber > 0) && (GelPercent > 0) && (SelectedArcyPercent > 0));
            }
        }
    }
}
