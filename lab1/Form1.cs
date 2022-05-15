using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String big_string;

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList listString = new ArrayList();
            ArrayList listDigits = new ArrayList();
            var bigListStr = new List<String>();
            ArrayList bigListDig = new ArrayList();
            ArrayList arrayIndexes = new ArrayList();
            ArrayList array = new ArrayList();
            Console.WriteLine(big_string);
            label3.Text = big_string;
            if (char.IsLetter(big_string[big_string.Length-1]))
            {
                big_string = big_string+"0";
            }
            else
            {
                big_string = big_string+"a";
            }
            for (int i = 1; i<big_string.Length; i++)
            {
              
                if (char.IsLetter(big_string[i-1]) && char.IsLetter(big_string[i]))
                {
                    listString.Add(big_string[i-1]);
                }
                if (char.IsLetter(big_string[i-1]) && char.IsDigit(big_string[i]))
                {
                    listString.Add(big_string[i-1]);
                    bigListStr.Add(String.Concat(listString.ToArray()));
                    listString.Clear();
                }
                if (char.IsDigit(big_string[i-1]) && char.IsDigit(big_string[i]))
                {
                    listDigits.Add(big_string[i-1]);
                }
                if (char.IsDigit(big_string[i-1]) && char.IsLetter(big_string[i]))
                {
                    listDigits.Add(big_string[i-1]);
                    bigListDig.Add(String.Concat(listDigits.ToArray()));
                    listDigits.Clear();
                }
                if (char.IsPunctuation(big_string[i-1]) && char.IsDigit(big_string[i]))
                {
                    listDigits.Add(big_string[i-1]);
                }
                if (char.IsDigit(big_string[i-1]) && char.IsPunctuation(big_string[i]))
                {
                    listDigits.Add(big_string[i-1]);
                
                }

            }
          
            var sortedlistStr = bigListStr.OrderBy(x => x.Length).Reverse().ToList<string>();
            PrintValues(sortedlistStr);
            var sortedListDig = bigListDig.Cast<string>().OrderBy(item => double.Parse(item)).Reverse();
            PrintValues(sortedListDig);
            var sortedListDigStr = sortedListDig.Cast<string>().ToList();
            if (char.IsLetter(big_string[0]))
            {     
                    
                    for (int i = 0; i < bigListStr.Count + bigListDig.Count; i++)
                    {
                    if (i%2==0)
                    {
                        array.Add(sortedlistStr[i/2]+";");
                        
                    }
                    else
                    {
                        array.Add(sortedListDigStr[(i-1)/2]+";");
                        
                    }
                }

            }
            else
            {
                for (int i = 0; i < bigListStr.Count + bigListDig.Count; i++)
                {
                    if (i%2==0)
                    {
                        array.Add(sortedListDigStr[i/2]+";");
                       
                    }
                    else
                    {
                        array.Add(sortedlistStr[(i-1)/2]+";");
                        
                    }
                }
            }
            Console.WriteLine(String.Concat(array.ToArray()));
            label3.Text = String.Concat(array.ToArray());
        }
        
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.WriteLine("   {0}", obj);
            Console.WriteLine();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            big_string = textBox1.Text;
        }

    }
}
