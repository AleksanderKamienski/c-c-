using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace piate_
{
    class NumbersConverter
    {
        int[][] bases;
        public NumbersConverter()
        {
            bases = bases = new int[29][];

            for (int i = 2; i < 31;++i)
            {
                int x = (int)Math.Log(i, 1000000);
                bases[i-2] = new int[x];
                for (int j = 0; j < bases[i-2].Length; ++j)
                    bases[i-2][j] = (int)Math.Pow(i, j);
            }

        }

        public int ConvertToDecimal(NumberInBase x)
        {
            int sum = 0;



            for (int i=0; i< x.number.Length; ++i)
            {
                if ((int)Char.GetNumericValue(x.number[x.number.Length - i - 1]) < 10 && (int)Char.GetNumericValue(x.number[x.number.Length - i - 1]) > -1)
                    sum += (int)Char.GetNumericValue(x.number[x.number.Length - i - 1]) * (int)(Math.Pow(x.b, i));
                else
                {
                    if (x.number[x.number.Length - i - 1] == 'A')
                    {
                        sum += 10 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'B')
                    {
                        sum += 11 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'C')
                    {
                        sum += 12 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'D')
                    {
                        sum += 13 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'E')
                    {
                        sum += 14 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'F')
                    {
                        sum += 15 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'G')
                    {
                        sum += 16 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'H')
                    {
                        sum += 17 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'I')
                    {
                        sum += 18 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'J')
                    {
                        sum += 19 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'K')
                    {
                        sum += 20 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'L')
                    {
                        sum += 21 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'M')
                    {
                        sum += 22 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'N')
                    {
                        sum += 23 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'O')
                    {
                        sum += 24 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'P')
                    {
                        sum += 25 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'Q')
                    {
                        sum += 26 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'R')
                    {
                        sum += 27 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'S')
                    {
                        sum += 28 * (int)(Math.Pow(x.b, i));
                    }
                    if (x.number[x.number.Length - i - 1] == 'T')
                    {
                        sum += 29 * (int)(Math.Pow(x.b, i));
                    }
                }

            }
            return sum;
        }
        public NumberInBase ConvertFromDecimal(int n, int b)
        {
            NumberInBase x = new NumberInBase();
            char[] z = {'A','B','C','D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'M', 'N', 'O', 'P', 'Q', 'R','S','T'};

            x.b = b;
           
            int add = 0;
           
            int how_long = 0;
            int pow = 1;
            while(pow<n || pow ==n)
            {
                pow *= b;
                how_long++;
            }

            if (how_long == 0)
                how_long = 1;

            char[] array = new char[how_long];
            for (int i = 0; i < how_long; ++i)
            {
                
                
                    add = (int)(n % (Math.Pow(b, i + 1)));
                    add = add / (int)Math.Pow(b, i);
                    n -= n % (int)(Math.Pow(b, i + 1));
                    if(add>9)
                    array[i] = z[add - 10];
                    else
                    array[i] = (char)(add + 48);
                

            }
           
            Array.Reverse(array);
            string num = new string(array);

            x.number = num;

            return x;
        }
        
    }
}
