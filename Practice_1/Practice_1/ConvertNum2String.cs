using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public class ConvertNum2String
    {
        private readonly Dictionary<int, string> _under20Dict;
        private readonly Dictionary<int, string> _tensDict;
        private readonly Dictionary<int, string> _separators;

        public ConvertNum2String()
        {
            _under20Dict = new Dictionary<int, string>()
                       {
                {0, "" },
                {1, "One"},
                {2, "Two" },
                {3, "Three" },
                {4, "Four" },
                {5,"Five" },
                {6,"Six" },
                {7,"Seven" },
                {8, "Eight" },
                {9, "Nine" },
                {10, "Ten" },
                {11, "Eleven" },
                {12, "Twelve" },
                {13, "Thirteen" },
                {14, "Fourteen" },
                {15, "Fifteen" },
                {16, "Sixteen" },
                {17, "Seventeen" },
                {18, "Eighteen" },
                {19, "Nineteen" }
                       };

            _tensDict = new Dictionary<int, string>()
                        {
                {2, "Twenty" },
                {3, "Thirty" },
                {4, "Fourty" },
                {5, "Fifty" },
                {6, "Sixty" },
                {7, "Seventy" },
                {8, "Eighty" },
                {9, "Ninety" }
                        };

            _separators = new Dictionary<int, string>()
                          {
                {3, "Billion" },
                {2, "Million" },
                {1, "Thousand" },
                          };
        }
        public string Num2String(long num)
        {
            if(num > 9000000000 || num < 0)
                throw new ArgumentOutOfRangeException(nameof(num));

            List<int> separatedNum = new List<int>();
            var val = num;
            if (val == 0) return "Zero";
            var separator = 1000;
            while (val > 0)
            {
                separatedNum.Add((int)(val % separator));
                val = val / separator;
            }

            List<string> numStrs = new List<string>();
            for (int i = separatedNum.Count - 1; i >= 0; i--)
            {
                if(separatedNum[i] <= 0)
                    continue;
                
                var section = Num2StrUnder100(separatedNum[i]);
                numStrs.Add(section);

                string s;
                if (_separators.TryGetValue(i, out s))
                    numStrs.Add(s);
            }
            return string.Join(" ", numStrs.Where(x => !string.IsNullOrEmpty(x)));
            
        }

        public string Num2StrUnder100(int num)
        {
            List<string> numStrs = new List<string>();
            if (num >= 100)
            {
                numStrs.Add(_under20Dict[num / 100]);
                numStrs.Add("Hundred");
                num = num % 100;
            }

            if (num >= 20)
            {
                numStrs.Add(_tensDict[num / 10]);
                num = num % 10;
            }
            numStrs.Add(_under20Dict[num]);

            return string.Join(" ", numStrs.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
