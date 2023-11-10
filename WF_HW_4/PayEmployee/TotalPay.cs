using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_4
{
    class TotalPay
    {
        double pay;
        int aboveNormHour;
        public int normPerMonth { get; set; }
        public double IncomeTax { get; set; }
        public double SalaryCalculation(int hours,double payPerHour)
        {
            if (normPerMonth < hours)
            {
               aboveNormHour=hours-normPerMonth;
                pay= ((normPerMonth*payPerHour) + (aboveNormHour*payPerHour)*2)-
               ((normPerMonth * payPerHour) + (aboveNormHour * payPerHour) * 2) * (IncomeTax / 100);
                return pay;
            }
            pay =(hours*payPerHour)-(hours * payPerHour*(IncomeTax/100));
            return pay;
        }
    }
}
