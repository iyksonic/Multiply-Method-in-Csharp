using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = MultiplyNum("1548575843847584839293293943450011", "20987876567890987655");
            //d.ForEach(Console.WriteLine);
            //var f = bigAdd("360", "3600");
            Console.WriteLine(d);
            Console.ReadLine();
        }
        public static string MultiplyNum(string a, string b)
        {
            List<string> somelist = new List<string>();
            string Total = "";
            int carry = 0;
            int maxlength = b.Length;
            int minlength = a.Length;
            int l = 0;
            string max;
            string min;
            if (b.Length > a.Length)
            {
                maxlength = b.Length;
                max = b;
                minlength = a.Length;
                min = a;
            }
            else
            {
                maxlength = a.Length;
                max = a;
                minlength = b.Length;
                min = b;
            }


            for (int i = minlength - 1; i >= 0; i--)
            {
                int minf = Convert.ToInt32(min[i].ToString());

                for (int j = maxlength - 1; j >= 0; j--)
                {
                    // int a1 = Convert.ToInt32(a[i].ToString());
                    // int b1 = Convert.ToInt32(b[i].ToString());
                    int maxf = Convert.ToInt32(max[j].ToString());

                    int Result = minf * maxf + carry;
                    carry = 0;

                    if (Result > 9)
                    {
                        Total = (Result % 10) + Total;
                        carry = Result / 10;
                    }
                    else
                    {
                        Total = Result + Total;
                    }
                }
                if (carry != 0)
                {
                    Total = carry + Total;
                    carry = 0;
                }
                if (i == (minlength - 2))
                {
                    l = Total.Length;
                }
                if (i < (minlength - 1))
                {
                    l++;
                    Total = Total.PadRight(l, '0');

                }
                somelist.Add(Total);
                Total = "";
            }
            string add = somelist[0];
            for (int k = 0; k < somelist.Count; k++)
            {
                if (k < somelist.Count - 1)
                {
                    string second = somelist[k + 1];
                    add = bigAdd(add, second);
                }
            }
            return add;
        }

        
        public static string bigAdd(string a, string b)
        {
            string Total = "";
            int carry = 0;
            int maxlength = b.Length;
            a = a.PadLeft(maxlength, '0');
            b = b.PadLeft(maxlength, '0');

            for (int i = maxlength - 1; i >= 0; i--)
            {
                int a1 = Convert.ToInt32(a[i].ToString());
                int b1 = Convert.ToInt32(b[i].ToString());
                int Result = a1 + b1 + carry;
                carry = 0;

                if (Result > 9)
                {
                    Total = Total + (Result - 10);
                    carry = 1;
                }
                else
                {
                    Total = Result + Total;
                }

            }
            if (carry != 0)
            {
                Total = carry + Total;
            }
            return Total;
        }
        
    }
}
