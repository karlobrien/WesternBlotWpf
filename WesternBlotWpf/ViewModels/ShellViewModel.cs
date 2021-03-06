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
            var wb = new WesternBlotViewModel {DisplayName = "Western Blot"};
            var cv = new CardViewModel { DisplayName = "Western Blot" };
            ActivateItem(cv);
        }
    }
}