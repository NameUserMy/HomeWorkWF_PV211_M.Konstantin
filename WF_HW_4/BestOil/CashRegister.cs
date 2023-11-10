using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_4
{
    class CashRegister
    {
        double bill;
        public double IncomePerDay { get; set; }
        public double Litrs { get; set; }
        public double SumGas { get; set; }
        public double SumCafe { get; set; }
        public double GasolineCash(double priceGas,bool money=false)
        {
            if (money)
            {
               Litrs= SumGas/priceGas;
               return Math.Round(Litrs,2);
            }else { SumGas = priceGas * Litrs; }
            return Math.Round(SumGas,2);
        }
        public double MiniCafe(List<Product> products)
        {
            SumCafe =  products.Where(p=>p.Count>0).Sum(p => p.Price*p.Count);
            return SumCafe;
        }
        public double BillCount()
        {
            bill = SumGas + SumCafe;
            return bill;
        }
    }
}
