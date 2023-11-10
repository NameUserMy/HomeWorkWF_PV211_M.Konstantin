using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_4
{
    public partial class Pay : Form
    {
        List<Employee> employees;
        TotalPay totalPay;
        public Pay()
        {
           InitializeComponent();
            totalPay = new TotalPay();
            employees = new List<Employee> { new Employee("Name","Sure Name","Last name",100,25),
                new Employee("Name", "Sure Name", "Last name",90, 15),
                new Employee("Name","Sure Name","Last name",120,30) };
            totalPay.IncomeTax = 12;
            totalPay.normPerMonth = 144;
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            DataGridView employee = new DataGridView()
            {
                Width = ClientSize.Width - 70,
                Height = ClientSize.Height,
                ReadOnly = true,
                BackgroundColor = Color.LightCyan,
            };
            employee.DataSource = employees;
            this.Controls.Add(employee);
            employee.Columns.Add("employeeIncome", $"Зарплата (С учётом П.Н. {totalPay.IncomeTax} %)");
            employee.Columns["employeeIncome"].AutoSizeMode=DataGridViewAutoSizeColumnMode.ColumnHeader;
            employee.Columns["employeeIncome"].ReadOnly = true;
            for (int i = 0; i < employee.Rows.Count; i++)
            {
                employee[employee.Columns.Count - 1, i].Value = totalPay.SalaryCalculation(employees[i].HoursPerMonth, employees[i].PayPerHour);
            }
        }
    }
}
