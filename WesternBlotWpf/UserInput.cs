using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf
{
    public class UserInput : IUserInput
    {
        public double numGel { get; set; }
        public double percentGel { get; set; }
        public int percentArcy { get; set; }

        public UserInput(double nGel, double pGel, int pArcy)
        {
            numGel = nGel;
            percentGel = pGel;
            percentArcy = pArcy;
        }
    }
}
