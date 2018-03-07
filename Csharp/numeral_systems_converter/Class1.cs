using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piate_
{
    class NumberInBase
    {
        public int b
        {
            get; set;
        }
        public string number
        {
            get; set;
        }


    public NumberInBase()
        {
            b = 10;
            number = "0";
        }
        public NumberInBase(int n)
        {
            b = 10;
            string num = "";
            int add = 0;
            string x = n.ToString();
            int how_long = x.Length;
            for(int i = 0;i < how_long; ++i)
            {
                add = (int)(n % (Math.Pow(10, i + 1)));
                add = add / (int)Math.Pow(10, i);
                n -= n % (int)(Math.Pow(10, i + 1));
                num += add.ToString();
                
            }
            char[] array = num.ToCharArray();
            Array.Reverse(array);
            num = new string(array);

            number = num;

        }
        public NumberInBase(string s,int b)
        {
           
            this.b = b;
            number = s;

        }

        public string Print()
        { 
           return "(" + number + ")" + "_" + b.ToString(); 
        }

    }
}
