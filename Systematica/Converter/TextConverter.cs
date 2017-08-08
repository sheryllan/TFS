using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class TextConverter
    {

        public string inToText(int value)
        {
            if (value == 0)
                return "0";

            List<char> charDigits = new List<char>();
            int divisor = 10;
            bool isNeg = value < 0;

	        while(value != 0)
	        {
		        int digit = Math.Abs(value % divisor);
                charDigits.Add((char)(digit + '0'));
                value = value / divisor;
	        }

	        if(isNeg)
                charDigits.Add('-');

	        int count = charDigits.Count;
	        for(int i = 0; i < count / 2; i++)
	        {
		        char temp = charDigits[i];
                charDigits[i] = charDigits[count - 1 - i];
		        charDigits[count - 1 - i] = temp;
		
	        }

	        return new string(charDigits.ToArray());

        }
    }
}
