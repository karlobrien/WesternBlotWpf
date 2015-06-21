using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace WesternBlotWpf
{
    public class PageOneViewModel : Screen
    {
        protected override void OnActivate()
        {
            MessageBox.Show("Page One Activated");
            base.OnActivate();
        }
    }
}
