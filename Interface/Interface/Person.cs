using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Interface
{
    public class Person : IPerson<string>
    {
        IEnumerable IPerson.Add()
        {
            Console.WriteLine("Return from IPerson.Add()");
            return Add();
        }

        public IEnumerator<string> Update()
        {
            Console.WriteLine("Return from IPerson<T>.Update()");
            string[] name = {"John", "H"};
            foreach (var n in name)
            {
                yield return n;
            }
        }

        IEnumerator IPerson.NgeneicAdd()
        {
            Console.WriteLine("Return from IPerson.Add()");
            string[] name = { "KY", "U" };
            foreach (var n in name)
            {
                yield return n;
            }
        }

        public IEnumerable<string> Add()
        {
            Console.WriteLine("Return from IPerson<T>.Add()");
            string[] name = { "Alan", "D" };
            foreach (var n in name)
            {
                yield return n;
            }
        }

        IEnumerator IPerson.Update()
        {
            Console.WriteLine("Return from IPerson.Update()");
            return Update();
        }

        IEnumerable<string> IPerson<string>.GenericAdd()
        {
            return this.Add();
        }

        int IPerson.Test1()
        {
            return Test1() - 1;
        }

        public int Test1()
        {
            return 11;
        }

        int IPerson.Test2()
        {
            return 20;
        }

        int IPerson<string>.Test3()
        {
            return 20 + Test1();
        }
    }
}
