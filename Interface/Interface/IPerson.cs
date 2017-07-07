using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IPerson
    {
        IEnumerable Add();
        IEnumerator Update();

        IEnumerator NgeneicAdd();

        int Test1();
        int Test2();

    }

    public interface IPerson<out T> : IPerson
    {
        // The generic version of IPerson just hides the methods in its non-generic base interface
        new IEnumerable<T> Add();
        new IEnumerator<T> Update();
        IEnumerable<T> GenericAdd();

        new int Test1();

        int Test3();
    }
}
