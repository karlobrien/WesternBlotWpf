using Caliburn.Micro;
using WesternBlotWpf.Model;

namespace WesternBlotWpf.ViewModels 
{
    public class ShellViewModel : Conductor<object>, IShell
    {
        public ShellViewModel()
        {
            ShowMainPage();
        }

        public void ShowMainPage()
        {
            ActivateItem(new WesternBlotViewModel(new CalculateModel()));
        }
    }
}