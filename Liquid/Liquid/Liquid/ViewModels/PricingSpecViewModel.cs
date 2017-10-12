using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquid.AssessmentLibrary;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;

namespace Liquid.ViewModels
{
    public class PricingSpecViewModel : BindableBase
    {
        private PricingSpecData _model;
        private string _name;
        private ObservableCollection<ContractDataViewModel> _contractRows;

        public PricingSpecData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value);
                if (_model == null) return;
                Name = Model.Name;
                ContractRows = new ObservableCollection<ContractDataViewModel>(Model.ContractRows.Select(x => new ContractDataViewModel(x)));
            }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<ContractDataViewModel> ContractRows
        {
            get { return _contractRows; }
            set { SetProperty(ref _contractRows, value); }
        }

        public PricingSpecViewModel(PricingSpecData model)
        {
            Model = model;
        }
    }
}
