using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace WesternBlotWpf
{
    public class WesternBlotViewModel : Screen
    {
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

        private decimal _gelPercentage;
        public decimal GelPercentage
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
        public decimal Arcylamide { get; set; }
        public BindableCollection<string> Results { get; set; } 

        public WesternBlotViewModel()
        {
            NumberOfGels = 3;
            GelPercentage = 23;
            Arcylamide = 345;
        }

        public void Calculate()
        {
            MessageBox.Show("Calculate");
        }

        public bool CanCalculate
        {
            get
            {
                return _numberOfGels > 0 && _gelPercentage > 0;
            }
            
        }
    }
}
