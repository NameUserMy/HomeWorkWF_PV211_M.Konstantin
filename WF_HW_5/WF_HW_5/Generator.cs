using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_HW_5
{
    class Generator
    {
        Random number;
        char genSome;
        delegate string choiceSimbol();
        choiceSimbol[] generater;
        StringBuilder password;
        string forNoRepeat;
        string Number()
        {
            return GenerAscii(48, 57);
        }
        string UpperLetter()
        {
            return GenerAscii(65,90);
        }
        string LowerLetter()
        {
            return GenerAscii(97,122);
        }
        string SpecSimbol()
        {

            return GenerAscii(33,47);
        }
        bool Norepeat(StringBuilder password,string forNoRepeat)
        {
            for (int j = 0; j < password.Length; j++)
            {
                if (password[j].ToString() != forNoRepeat.ToString())
                {
                    continue;
                }
                else { return false; };
            }
            return true;
        }
        string GenerAscii(int startAsciiCode, int endtAsciiCode)
        {
            genSome = Convert.ToChar(number.Next(startAsciiCode,endtAsciiCode));
            return genSome.ToString();

        }
        public string DerParol(int length,List<int> check,bool noRepeat)
        {
            password = new StringBuilder(length);
            if (noRepeat)
            {
                for (int i = 0; i <length;)
                {
                    forNoRepeat = generater[check[number.Next(0, check.Count)]].Invoke();
                    if (i > 0)
                    {
                        if (Norepeat(password, forNoRepeat))
                        {
                            password.Append(forNoRepeat); i++;
                        }
                        else {continue;}
                    }
                    else {password.Append(forNoRepeat); i++;}
                }
            }
            else {
                  for (int i = 0; i < length; i++)
                {
                    password.Append(generater[check[number.Next(0, check.Count)]].Invoke());
                }
            }

            return password.ToString();
        }
        public string DerParolForSelf(string selfGeneration)
        {
            password = new StringBuilder(selfGeneration.Length);
            
            for (int i = 0; i < selfGeneration.Length; i++)
            {
                
                if(password.Length<=32)
                 password.Append(selfGeneration[number.Next(0, selfGeneration.Length)]);
                else
                {
                    return password.ToString();
                }

            }
           
            return password.ToString();
        }
        public Generator()
        {
            number= new Random();
            generater = new choiceSimbol[]{ Number, LowerLetter, UpperLetter, SpecSimbol };
            
        }
    }

}