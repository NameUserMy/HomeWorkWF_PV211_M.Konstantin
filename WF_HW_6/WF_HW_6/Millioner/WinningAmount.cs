using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_6
{
    class WinningAmount
    {
        int[] _sum;
        public int [] GetSum() { { return _sum; } }
        public WinningAmount()
        {
            _sum = new int[] {1000000, 500000, 250000, 125000, 64000, 32000, 16000, 8000, 4000, 2000, 1000, 500, 300, 200, 100};
        }
    }
}
