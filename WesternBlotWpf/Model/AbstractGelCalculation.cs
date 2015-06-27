using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf.Model
{
    public abstract class AbstractGelCalculation
    {
        public abstract BlotParts CreateBlotParts(double numGel, double percentGel, double percentArcy);

    }
}
