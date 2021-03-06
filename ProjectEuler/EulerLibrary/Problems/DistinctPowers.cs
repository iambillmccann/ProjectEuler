﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class DistinctPowers : IEulerSolution
    {
        /// <summary>
        /// Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:
        ///
        /// 22=4, 23=8, 24=16, 25=32
        /// 32=9, 33=27, 34=81, 35=243
        /// 42=16, 43=64, 44=256, 45=1024
        /// 52=25, 53=125, 54=625, 55=3125
        ///        
        /// If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:
        ///
        /// 4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125
        ///
        /// How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
        /// </summary>
        /// <returns></returns>
        private long maxNumber = 5;
        private Dictionary<string, int> exponentials;

        public DistinctPowers(long maxNumber)
        {
            this.maxNumber = maxNumber;
            exponentials = new Dictionary<string, int>();
        }

        /// <summary>
        /// Return a string that represents the prime factors of a number to the
        /// power of an exponent.
        /// </summary>
        /// <param name="primeFactors"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public string AllFactors(List<long> primeFactors, long exponent)
        {
            long[] arrayOfFactors = new long[1000];
            int element = 0;

            for (long index = 0; index < exponent; index++)
                foreach (long factor in primeFactors)
                {
                    arrayOfFactors[element] = factor;
                    element++;
                }

            string result = null;
            Array.Sort(arrayOfFactors);
            foreach (long factor in arrayOfFactors) result = result + "|" + factor.ToString();

            return result;
        }

        /// <summary>
        /// The compute method loops through the premutations of numbers and exponents and
        /// determines the prime factors of the result (rather than computing the answer).
        /// These are added to a dictionary to insure uniqueness.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            for (long integer = 2; integer <= maxNumber; integer++)
            {
                List<long> primeFactors = MathLibrary.GetFactors(integer);
                for (long exponent = 2; exponent <= maxNumber; exponent++)
                {
                    // This inner loop traverse through each number/exponent combination
                    string allFactors = AllFactors(primeFactors, exponent);
                    try
                    {
                        exponentials.Add(allFactors, 1);
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
            }

            return exponentials.Count.ToString();
        }

    }
}
