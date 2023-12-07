using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW_8.Temperature.Model
{
    class Day
    {
        public string DayOfWeek { get; set; }
        private  double[] _temperature;

        public double[]  Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public Day()
        {

            _temperature = new double[12];
        }

        public Day(string dayOfWeek, double[] temperature)
        {
            DayOfWeek = dayOfWeek;
            Temperature = temperature;
            
        }
        public override string ToString()
        {
            return $"{DayOfWeek}";
        }
    }
}
