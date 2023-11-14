using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_6
{
    class Answer
    {
        public string TruAnswer { get; set; }
        string[] Answers;
        public string[] GetAnswer()
        {
            return Answers;
        }
        public Answer(string truAnswer, string[] answers)
        {
            Answers = new string[4];
            TruAnswer = truAnswer;
            Answers[0] = truAnswer;
            for (int i = 1; i < Answers.Length; i++)
            {
                Answers[i] = answers[i-1];
            }

        }
    }
}
