using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace WesternBlotWpf
{
    public class BlotParts : PropertyChangedBase
    {
        private double _dH20;
        private double _acrylamide;
        private double _tris1;
        private double _tris2;
        private double _sds;
        private double _aps;
        private double _temed;
        private double _totalVolume;

        public double Dh20
        {
            get
            {
                return _dH20;
            }
            set
            {
                if (Math.Abs(_dH20 - value) < 0)
                    return;
                _dH20 = value;
                NotifyOfPropertyChange(() => Dh20);
            }
        }

        public double Acrylamide
        {
            get { return _acrylamide; }
            set
            {
                if (Math.Abs(_acrylamide - value) < 0)
                    return;
                _acrylamide = value;
                NotifyOfPropertyChange();
            }
        }

        public double Tris2
        {
            get { return _tris2; }
            set
            {
                if (Math.Abs(_tris2 - value) < 0)
                    return;
                _tris2 = value;
                NotifyOfPropertyChange();
            }
        }

        public double Tris1
        {
            get
            {
                return _tris1;
            }
            set
            {
                if (Math.Abs(_tris1 - value) < 0)
                    return;
                _tris1 = value;
                NotifyOfPropertyChange();
            }
        }

        public double Sds
        {
           get
            {
                return _sds;
            }
            set
            {
                if (Math.Abs(_sds - value) < 0)
                    return;
                _sds = value;
                NotifyOfPropertyChange();
            }
        }

        public double Aps
        {
            get
            {
                return _aps;
            }
            set
            {
                if (Math.Abs(_aps - value) < 0)
                    return;
                _aps = value;
                NotifyOfPropertyChange();
            }
        }

        public double Temd
        {
            get
            {
                return _temed;
            }
            set
            {
                if (Math.Abs(_temed - value) < 0)
                    return;
                _temed = value;
                NotifyOfPropertyChange();
            }
        }

        public double TotalVolume
        {
            get
            {
                return _totalVolume;
            }
            set
            {
                if (Math.Abs(_totalVolume - value) < 0)
                    return;
                _totalVolume = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
