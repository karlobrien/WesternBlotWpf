using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace WesternBlotWpf
{
    public class PageTwoViewModel : Screen
    {
        protected override void OnActivate()
        {
            MessageBox.Show("Page Two Activated");
            base.OnActivate();
        }
    }
}
