using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_4
{
    public partial class BestOil : Form
    {
       
        List<Product> cafeProduct;
        List<Product> gasProduct;
        CashRegister cashRegister;
        public BestOil()
        {
            InitializeComponent();
           
            cashRegister = new CashRegister();
            cafeProduct = new List<Product> {new Product(44.0,"Banana"), new Product(20.0, "Cofe"), new Product(120, "Hot-Dog"), new Product(33, "Tea") };
            gasProduct = new List<Product> {new Product(58.0,"A-95"), new Product(63.0,"A-98"), new Product(80.0, "A-100")};
            this.ClientSize = new Size(700, 450);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            gasStationGroup = new GroupBox()
            {
                Width = this.ClientSize.Width / 2 - 10,
                Height = this.ClientSize.Height - this.ClientSize.Height / 3,
                Text = "Авто заправка",
                ForeColor = Color.FromArgb(0, 139, 139),
                Name = "gasStation",
                Location = new Point(10, 20)
            };
            snackGroup = new GroupBox()
            {
                Width = this.ClientSize.Width / 2 - 20,
                Height = this.ClientSize.Height - this.ClientSize.Height / 3,
                Text = "Мини кафе",
                ForeColor = Color.FromArgb(0, 139, 139),
                Name = "snack",
                Location = new Point(this.ClientSize.Width / 2 + 10, 20)
            };
            billGroup = new GroupBox()
            {
                Height = ClientSize.Height / 3 - 30,
                Width = ClientSize.Width - 20,
                Text = "Всего к оплате",
                ForeColor = Color.FromArgb(0, 139, 139),
                Name = "sum",
                Location = new Point(10, ClientSize.Height - ClientSize.Height / 3 + 25)
            };
            billLabel = new Label()
            {

                Text = $"{cashRegister.BillCount()} грн",
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold),
                Padding = new Padding(240,30,10,1),


            };
            billButton = new Button()
            {
                Text = "Оплатить",
                Dock = DockStyle.Left
            };
            
        }
        private void BestOil_Load(object sender, EventArgs e)
        {
            RenderGasoline();
            this.Controls.Add(gasStationGroup);
            this.Controls.Add(snackGroup);
            this.Controls.Add(billGroup);
            billGroup.Controls.Add(billButton);
            billGroup.Controls.Add(billLabel);
            gasStationGroup.Controls.Add(gas);
            gasStationGroup.Controls.Add(price);
            gasStationGroup.Controls.Add(сurrency);
            gasStationGroup.Controls.Add(сurrency1);
            gasStationGroup.Controls.Add(liters);
            gasStationGroup.Controls.Add(gasCombobox);
            gasStationGroup.Controls.Add(gasPriceTB);
            gasStationGroup.Controls.Add(choiceGroubB);
            gasStationGroup.Controls.Add(gasLitersTB);
            gasStationGroup.Controls.Add(gasSumTB);
            gasStationGroup.Controls.Add(gasToPay);
            gasToPay.Controls.Add(AmountforGasoline);
            
            choiceGroubB.Controls.Add(moneyRB);
            choiceGroubB.Controls.Add(litersRB);

            RenderCafe();
            GasolineMark();
            moneyRB.CheckedChanged+=ChoiceLiterOrMoney;
            gasLitersTB.ValueChanged += MoneyCount;
            gasSumTB.TextChanged += LitersCount;
            gasCombobox.SelectedIndexChanged += PriceGas;
            billButton.Click += Bill;
            this.Closing += new CancelEventHandler(this.CloseProgramm);

        }
        /*--------------------------Gasoline----------------------------*/

        void RenderGasoline()
        {
            choiceGroubB = new GroupBox() { Width = 140, Height = 70, Location = new Point(20, 125) };
            gasToPay = new GroupBox()
            {
                Text = "К оплате за бензин",
                Width = gasStationGroup.Width - 50,
                Height = gasStationGroup.Height / 3 - 10,
                Location = new Point(20, 200),
                ForeColor = Color.FromArgb(0, 139, 139),
                Padding = new Padding(30, 20, 10, 10),
            };

            gas = new Label() { Text = "Бензин", Location = new Point(20, 50), Width = 50 };
            price = new Label() { Text = "цена", Location = new Point(gas.Location.X, gas.Location.Y + 50), Width = 50 };
            сurrency = new Label() { Width = 35, Text = "грн/л.", Location = new Point(260, 105) };
            сurrency1 = new Label() { Width = 30, Text = "грн.", Location = new Point(260, 172) };
            liters = new Label() { Width = 30, Text = "л.", Location = new Point(260, 132) };

            AmountforGasoline = new Label()
            {
                Width = 100,
                Height = 30,
                Text = $" {cashRegister.SumGas}грн",
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold),
            };

            gasCombobox = new ComboBox() {Width = 150, Location = new Point(gas.Width + 60, gas.Location.Y) };
            gasPriceTB = new TextBox()
            {
                Width = gasCombobox.Width,
                Location = new Point(gasCombobox.Location.X, price.Location.Y),
                ReadOnly = true
            };
            gasLitersTB = new NumericUpDown() { Width = gasCombobox.Width / 2 + 15, Location = new Point(170, 130) };
            gasSumTB = new MaskedTextBox()
            {
                Width = gasCombobox.Width / 2 + 15,
                Location = new Point(170, 170),
                ReadOnly = true,
                Mask = "00000"
            };

            litersRB = new RadioButton() { Text = "Количество", Location = new Point(10, 10), Checked = true, Tag = "Money" };
            moneyRB = new RadioButton()
            {
                Text = "Сумма",
                Location = new Point(10, choiceGroubB.Height - 25),
                Tag = "Liter",
            };

        }
        private void LitersCount(object sender, EventArgs e)
        {
            if (gasSumTB.Text.Length != 0)
            {
                cashRegister.SumGas = Convert.ToDouble(gasSumTB.Text.ToString());
                AmountforGasoline.Text = $"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} л";
                billLabel.Text = Text = $"{cashRegister.BillCount()} грн";
            }
            
        }
        private void MoneyCount(object sender, EventArgs e)
        {
            cashRegister.Litrs = (double)gasLitersTB.Value;
            AmountforGasoline.Text= $"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} грн";
            billLabel.Text = Text = $"{cashRegister.BillCount()} грн";
        }
        private void ChoiceLiterOrMoney(object sender,EventArgs e)
        {
            
            if (moneyRB.Checked) {
                gasToPay.Text = "К выдаче";
                cashRegister.SumGas = 0;
                gasLitersTB.Value = 0;
                AmountforGasoline.Text=$"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} л";
                billLabel.Text = Text = $"{cashRegister.BillCount()} грн";
                gasLitersTB.Enabled = false;
                gasSumTB.ReadOnly = false;
            }
            else
            {
                cashRegister.Litrs = 0;
                gasSumTB.Text ="";
                gasToPay.Text = "К оплате за бензин";
                AmountforGasoline.Text= $"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} грн";
                billLabel.Text = Text = $"{cashRegister.BillCount()} грн";
                gasLitersTB.Enabled = true;
                gasSumTB.ReadOnly = true;
            }
        }
        private void PriceGas(object sender, EventArgs e)
        {
            gasPriceTB.Text = gasProduct[gasCombobox.SelectedIndex].Price.ToString();
            _=(moneyRB.Checked)? AmountforGasoline.Text = $"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} л" 
                : AmountforGasoline.Text = $"{cashRegister.GasolineCash(gasProduct[gasCombobox.SelectedIndex].Price, moneyRB.Checked)} грн";
            billLabel.Text = Text = $"{cashRegister.BillCount()} грн";

        }
        void GasolineMark()
        {
            for (int i = 0; i < gasProduct.Count; i++)
            {
                gasCombobox.Items.Add(gasProduct[i].Title);
            }
            gasCombobox.SelectedIndex = 0;
        }
/*-------------------------------------------------------------*/

/*--------------------------Cafe----------------------------*/
        private void RenderCafe()
        {

            AmountforCafe = new Label()
            {
                Text = $"{ cashRegister.MiniCafe(cafeProduct) } грн",
                Width = 100,
                Height = 30,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold)
                
            };
            cafeToPay = new GroupBox()
            {
                Name = "Cafe",
                Text = "К оплате за продукты",
                Width = gasStationGroup.Width - 50,
                Height = gasStationGroup.Height / 3 - 10,
                Padding = new Padding(30, 20, 10, 10),
                Location = new Point(20, 200),
                ForeColor = Color.FromArgb(0, 139, 139),
            };
            for (int i = 1; i < cafeProduct.Count+1; i++)
            {
                choiceProductCB = new CheckBox()
                {
                    Text = cafeProduct[i - 1].Title,
                    Location = new Point(20, (20 * i) + i * 20),
                };
                var countProduct=new NumericUpDown()
                {
                    Name = cafeProduct[i - 1].Title,
                    Enabled = false,
                    Size = new Size(70, 10),
                    Location = new Point((snackGroup.Width - 75),
                    (20 * i) + i * 20),

                };
                snackGroup.Controls.Add(countProduct);
                snackGroup.Controls.Add(new TextBox() { ReadOnly=true, Text= cafeProduct[i-1].Price.ToString(),Size = new Size(70, 10), Location = new Point((snackGroup.Width - 75 * 2), (20 * i) + i * 20) });
                snackGroup.Controls.Add(choiceProductCB);
                choiceProductCB.CheckedChanged += ValueProduct;
                countProduct.ValueChanged += AmountCafe;
            }
            snackGroup.Controls.Add(cafeToPay);
            cafeToPay.Controls.Add(AmountforCafe);
            snackGroup.Controls.Add(new Label() {Name="priceLabel",Width=70,Text="Количество", Location = new Point(snackGroup.Width-75, 20) });
            snackGroup.Controls.Add(new Label() {Text="Цена", Location = new Point(snackGroup.Width -150, 20) });
        }
        private void AmountCafe(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            cafeProduct.Where(p => p.Title.Equals(num.Name)).
            FirstOrDefault().Count=(int)num.Value;
            AmountforCafe.Text=$"{cashRegister.MiniCafe(cafeProduct)} грн";
            billLabel.Text = Text = $"{cashRegister.BillCount()} грн";
        }
        private void ValueProduct(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            var value = snackGroup.Controls.OfType<NumericUpDown>().Where(x => x.Name.Equals(check.Text));
            _=(value.FirstOrDefault().Enabled = check.Checked)? value.FirstOrDefault().Value =0 : value.FirstOrDefault().Value = 0;
               
        }
/*-------------------------------------------------------------*/
        private void Bill(object sender, EventArgs e)
        {
            cashRegister.IncomePerDay += cashRegister.BillCount();
            var isClear = MessageBox.Show("Очистить заказ сейчас?", "Clear", MessageBoxButtons.YesNo);
            if (isClear == DialogResult.Yes)
            {
                ClearOrder(this);
            }
            else
            {
                TimerCallback test = new TimerCallback(ClearOrder);
                System.Threading.Timer timer = new System.Threading.Timer(test, null, 7_000, 1000);
            }
        }
        private void ClearOrder(object obj)
        {
            var clearCheck = snackGroup.Controls.OfType<CheckBox>().Where(x => x.Checked == true);
            foreach (var item in clearCheck) { item.Checked = false; }
            gasLitersTB.Value = 0;
            gasSumTB.Text = "0";

        }
        private void CloseProgramm(object sender, CancelEventArgs e)
        {
           
            var close=MessageBox.Show("Закрыть программу?","Close", MessageBoxButtons.YesNo);
           if(close == DialogResult.Yes)
            {
                MessageBox.Show($"Выручка задень {cashRegister.IncomePerDay}");
                e.Cancel = false;
            }else { e.Cancel = true; }
            
             
            
        }

        private CheckBox choiceProductCB;
        private RadioButton moneyRB;
        private RadioButton litersRB;
        private GroupBox gasStationGroup;
        private GroupBox snackGroup;
        private GroupBox billGroup;
        private GroupBox choiceGroubB;
        private GroupBox gasToPay;
        private GroupBox cafeToPay;
        private Label gas;
        private Label price;
        private Label сurrency;
        private Label сurrency1;
        private Label liters;
        private Label AmountforGasoline;
        private Label AmountforCafe;
        private Label billLabel;
        private Button billButton;
        private ComboBox gasCombobox;
        private TextBox gasPriceTB;
        private NumericUpDown gasLitersTB;
        private MaskedTextBox gasSumTB;

        
    }
}
