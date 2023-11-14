using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_6
{
    public partial class Questions : Form
    {
        WinningAmount fillWining;
        Dictionary<string,Answer> answer;
        List<Button> answerSet;
        Random rand;
        Timer timer;
        int stage;
        int randoms;
        int i;
        public Questions()
        {
            i = 10;
            InitializeComponent();
            rand=new Random();
            answerSet = new List<Button>();
            answerSet = answerOptionsGB.Controls.OfType<Button>().ToList();

            answer = new Dictionary<string, Answer>();
            answer.Add("some questions1 ?", new Answer("Tru Answer1",new string[] { "Answer 1", "Answer 2", "Answer 3" }));
            answer.Add("some questions2 ?", new Answer("Tru Answer2",new string[] { "Answer 2", "Answer 3", "Answer 4" }));
            fillWining = new WinningAmount();

            AnswerGenerate(stage);
            this.CenterToScreen();
            this.Load += StartLoad;
        }

        private void StartLoad(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += PrintTime;
            timer.Interval = 1000;
            timer.Start();
            sum.DataSource = fillWining.GetSum();
            sum.SelectedIndex = sum.Items.Count - 1;

            for (int i = 0; i < answerSet.Count; i++)
            {
                answerSet[i].Click += IsAnswer;
            };
            fiftyToFifty.Click += Exclude;
            callFriend.Click += CallFriends;
        }
        private void PrintTime(object sender, EventArgs e)
        {

            time.Text = i.ToString();
            if (i == 0)
            {
                timer.Stop();
                MessageBox.Show("Failure");
                this.Close();
                return;
            }
            else { --i; time.Text = i.ToString(); }
  
        }
        private void CallFriends(object sender, EventArgs e)
        {
            MessageBox.Show($"I think  {answer[answer.ElementAt(stage).Key].GetAnswer()[rand.Next(0,4)]}");
        }
        private void Exclude(object sender, EventArgs e)
        {
            
            int exclude = rand.Next(4);
            for (int i = 0; i < 2;)
            {
                
                if (answerSet[exclude].Text != answer[answer.ElementAt(stage).Key].TruAnswer && 
                    answerSet[exclude].Enabled != false)
                {
                    answerSet[exclude].Enabled = false;
                    answerSet[exclude].BackColor = Color.Red;
                    i++;
                }
                else { exclude = rand.Next(4); }
            }
            
        }
        private void IsAnswer(object sender, EventArgs e)
        {
            foreach (var item in answerSet) 
            {
                item.Enabled = true;
                item.BackColor = Color.DarkOrange;
            }
            string textButton = sender.ToString();
            if (textButton.EndsWith(answer[answer.ElementAt(stage).Key].TruAnswer))
            {
                
                sum.SelectedIndex--;
                stage++;
                AnswerGenerate(stage);
                i = 10;
                timer.Start();
            }
            else { MessageBox.Show("Failure"); this.Close();stage = 0; }
        }
        void AnswerGenerate(int stage)
        {
            randoms = rand.Next(4);
            questionTextB.Text = answer.ElementAt(stage).Key;
            for (int i = 0; i < answerSet.Count;)
            {
                if (answerSet.TrueForAll(x => x.Text != answer[answer.ElementAt(stage).Key].GetAnswer()[randoms]))
                {
                    answerSet[i].Text = answer[answer.ElementAt(stage).Key].GetAnswer()[randoms];
                    i++;
                }
                else { randoms = rand.Next(4); }
            }
        }
    }
}
