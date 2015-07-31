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
        public CardViewModel()
        {
            BlotParts separationResults = new BlotParts { GelName="Separation Gel" };
            BlotParts stackResults = new BlotParts { GelName = "Stacking Gel" };

            BlotResults = new ObservableCollection<BlotParts>();
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
            }
        }

        private ObservableCollection<BlotParts> _blotParts;
        public ObservableCollection<BlotParts> BlotResults
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
            Console.WriteLine(SelectedArcyPercent);
            SeparationGelCalculate model = new SeparationGelCalculate();
            UserInput userInput = new UserInput(GelNumber, GelPercent, SelectedArcyPercent);

            BlotResults[0] = model.CreateBlotParts(userInput);

            var result = model.CreateBlotParts(userInput);
        }
    }
}
