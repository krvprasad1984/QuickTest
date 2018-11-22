using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biggest_Neighbor
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new myclass();
            p.pro();
            
        }
        
    }
    class myclass
    {
        public void pro()
        {
            int i = 0;
            string a = "";
            int[] inp = new int[10];
            Console.WriteLine("Enter number from 0 to 9");
            for (i = 0; i <= 9; i++)
            {
                inp[i] = int.Parse(Console.ReadLine());
            }
            Challenge(inp);
        }

        public int Challenge(int[] input)
        {
            //your code here
            int[] reps;
            int[] uniq = input.Distinct().ToArray();
            reps = new int[uniq.Length];
            int el = 0, cnt = 0, res = 0;
            Console.WriteLine("\n");
            for (el = 0; el < uniq.Length; el++)
            {
                cnt = 0;
                int numb = uniq[el];
                for (int l = 0; l < input.Length; l++)
                {
                    if (numb == input[l])
                    {
                        cnt++;
                    }
                }
                Console.WriteLine("Number {0} is repeated {1} time(s)", numb, cnt);
                reps[el] = cnt;
            }
           
            //Finding maximum repitations
            int maxVal = reps[0];
            for (int i = 1; i < reps.Length; i++)
            {
                if (reps[i] > maxVal)
                    maxVal = reps[i];
            }

            //To find first biggest(M) number among same number of repetations
            int[] sames = new int[10];
            for (int i = 0; i < reps.Length; i++)
            {
                if (maxVal == reps[i])
                {
                    sames[i] = i;
                    //Console.WriteLine("{0}", sames[i]);
                }
            }
            int[] maxrepVal = new int[10];
            for (int i = 1; i < sames.Length; i++)
            {
                maxrepVal[i] = uniq[sames[i]];
            }
            int maxrepindex = Array.IndexOf(reps, maxVal);
            int maxrepnum = maxrepVal[maxrepindex];
            Console.WriteLine("\n");
            Console.WriteLine("Number {0} has max repetations(M) of {1}", maxrepVal.Max(), maxVal);


            //Check if there is M-1 REpetation is there or not
            //To find second most repeted(M-1) number among same number of repetations
            int max2Val = maxVal - 1;
            int[] sames2 = new int[10];
            for (int i = 0; i < reps.Length; i++)
            {
                if (max2Val == reps[i])
                {
                    sames2[i] = i;
                    // Console.WriteLine("{0}", sames2[i]);
                }
            }
            int[] max2repVal = new int[10];
            for (int i = 1; i < sames2.Length; i++)
            {
                max2repVal[i] = uniq[sames2[i]];

            }

            int max2repindex = Array.IndexOf(reps, max2Val);
            if (max2repindex >= 0)
            {
                int max2repnum = max2repVal[max2repindex];

                Console.WriteLine("Number {0} has 2nd Max repetations(M-1) {1}", max2repVal.Max(), max2Val);
                Console.WriteLine("\n");
                if (max2repVal.Max() > maxrepVal.Max())
                {
                    Console.WriteLine("Hence Max number with nighbourhoods is {0}", max2repVal.Max() * 2);
                }
                else
                {
                    Console.WriteLine("Hence Max number with nighbourhoods is {0}", maxrepVal.Max() * 2);
                }
            }
            else
            {
                if (maxVal > 1)
                {
                    Console.WriteLine("No numbers found with {0} repetations.\n", max2Val);
                    Console.WriteLine("Hence Max number with nighbourhoods is {0}", maxrepVal.Max() * 2);
                }
                else
                {
                    Console.WriteLine("No numbers found with {0} repetations.\n", max2Val);
                    Console.WriteLine("Hence Max number with nighbourhoods is {0}", maxrepVal.Max() + maxrepnum);
                }
            }

            Console.Read();
            return res;

        }

    }
}
