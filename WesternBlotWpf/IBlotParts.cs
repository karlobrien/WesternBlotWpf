using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesternBlotWpf
{
    public interface IBlotParts
    {
        string GelName { get; set; }
        double Dh20 { get; set; }
        double Acrylamide { get; set; }
        double Tris { get; set; }
        double Sds { get; set; }
        double Aps { get; set; }
        double Temd { get; set; }
        double TotalVolume { get; set; }      
    }
}
