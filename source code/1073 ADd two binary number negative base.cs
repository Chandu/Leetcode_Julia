﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1073_add_two_binary_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AddNegabinary(new int[]{1}, new int[]{1, 1, 0, 1}); 
        }

        /// <summary>
        /// Leetcode 1073 add two binary numbers - negative two based
        /// There are four possible values for the sum:
        ///  0 - 0
        ///  1 - 1
        ///  2 - 0 with carry -1
        ///  3 - 1 with carry -1
        /// -1 - 1 with carry  1
        /// How to introduce carry -1 instead of 1? How to understand that the carry can be 
        /// expressed in negative value? What is the advantage to use -1? 
        /// Two possible carry values, -1 and 1. 
        /// 
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static int[] AddNegabinary(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr2 == null)
                return new int[0];

            var length1 = arr1.Length;
            var length2 = arr2.Length;

            if (length1 > length2)
            {
                return AddNegabinary(arr2, arr1); 
            }

            var stack = new Stack<int>(); 

            int carry = 0; 
            // from rightmost digit to start to add two numbers digit by digit
            for (int i = 0; i < length2; i++)
            {
                var digit1 = arr2[length2 - 1 - i];
                var digit2 = i < length1 ? arr1[length1 - 1 - i] : 0;

                var sum = digit1 + digit2 + carry;

                if (sum == 0 || sum == 1)
                {
                    stack.Push(sum);
                    carry = 0; // reset, caught by online judge
                }                
                else if (sum == 2)
                {
                    stack.Push(0);
                    carry = -1; 
                }
                else if (sum == 3)
                {
                    stack.Push(1);
                    carry = -1; // caught by online judge
                }
                else if (sum == -1)
                {
                    stack.Push(1);
                    carry = 1;
                }
            }

            if (carry == 1)
            {
                stack.Push(1);
            }
            else if (carry == -1)
            {
                stack.Push(1);
                stack.Push(1);
            }

            // removing leading zero
            while (stack.Count > 1 && stack.Peek() == 0)
            {
                stack.Pop();
            }

            return stack.ToArray();             
        }
    }
}
