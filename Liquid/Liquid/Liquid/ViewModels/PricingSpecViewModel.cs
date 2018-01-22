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
    public class PricingSpecViewModel : BaseViewModel
    {
        private PricingSpecData _model;
        private ObservableCollection<ContractData> _contractRows;
        private List<Action> _modelActions;


        public PricingSpecData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value);
                Notify(_modelActions);
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
            _modelActions = new List<Action>
            {
                () => OnPropertyChanged(() => Name),
                () => ContractRows = new ObservableCollection<ContractData>(Model.ContractRows)
            };
        }

        public bool IsSamePricingSpec(PricingSpecData data)
        {
            return data?.Name == Name;
        }

    }
}
