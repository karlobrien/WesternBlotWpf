using System.Windows;
using Caliburn.Micro;

namespace WesternBlotWpf {
    
//    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
//    {
//        string name;
//
//        public string Name
//        {
//            get { return name; }
//            set
//            {
//                name = value;
//                NotifyOfPropertyChange(() => Name);
//                NotifyOfPropertyChange(() => CanSayHello);
//            }
//        }
//
//        public bool CanSayHello
//        {
//            get { return !string.IsNullOrWhiteSpace(Name); }
//        }
//
//        public void SayHello()
//        {
//            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
//        }
//    }

    public class ShellViewModel : Conductor<object>, IShell
    {
        public ShellViewModel()
        {
            ShowPageOne();   
        }

        public void ShowPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }
    }
}