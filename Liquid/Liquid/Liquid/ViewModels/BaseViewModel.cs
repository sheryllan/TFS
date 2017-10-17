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
        public List<Action> ObserverActions { get; set; }
        
        public virtual void Notify()
        {
            Update();
        }

        public void Update()
        {
            if(ObserverActions == null) return;
            foreach (var o in ObserverActions)
            {
                o.Invoke();
            }
        }

    }
}
