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
        private ObservableCollection<ContractData> _contractRows;

        public PricingSpecData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value);
                OnPropertyChanged(() => Name);
                ContractRows = new ObservableCollection<ContractData>(_model.ContractRows);
            }
        }

        public string Name { get { return Model?.Name; } }

        public ObservableCollection<ContractData> ContractRows
        {
            get { return _contractRows; }
            set { SetProperty(ref _contractRows, value); }
        }

        public PricingSpecViewModel(PricingSpecData model)
        {
            Model = model; 
        }

        public bool HasSamePricingSpec(PricingSpecData data)
        {
            return data?.Name == Name;
        }

    }
}
