using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf
{
    public interface IUserInput
    {
        double numGel { get;set; }
        double percentGel { get;set; }
        int percentArcy { get; set; }
    }
}
