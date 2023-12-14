using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW_3
{
    public partial class Products
    {

        private string _title;
        public string GetTitle
        {
            get { return _title; }
            private set { _title = value; }
        }
        private decimal _price;
        private string _description;

        public Products(string title, decimal price, string description)
        {
            _title = title;
            _price = price;
            _description = description;
        }
        public override string ToString()
        {
            return $"Title: {_title}\nPrise: {_price}\nDescription:\n{_description}";
        }
    }
}
