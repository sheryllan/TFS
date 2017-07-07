using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    public class LongestSubstring
    {

        public Tuple<int, int> Solution(string input)
        {
            int prev = 0;
            int current = 0;
            int prevLen = 0;
            int currentLen = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (currentLen > prevLen)
                {
                    prev = current;
                    prevLen = currentLen;
                }

                if (input[current] != input[i])
                {
                    current = i;
                    currentLen = 1;
                }
                else
                {
                    currentLen++;
                }
            }
            if (currentLen > prevLen)
            {
                prevLen = currentLen;
                prev = current;
            }

            return new Tuple<int, int>(prev, prevLen); 
        }
    }
}
