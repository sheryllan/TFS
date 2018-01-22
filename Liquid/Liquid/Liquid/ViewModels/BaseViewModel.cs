using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace Liquid.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        public virtual void Notify(IEnumerable<Action> actions)
        {
            Update(actions);
        }

        public void Update(IEnumerable<Action> actions)
        {
            if(actions == null) return;
            foreach (var o in actions)
            {
                o.Invoke();
            }
        }

    }
}
