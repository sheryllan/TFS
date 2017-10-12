using System;
using System.Globalization;
using Liquid.AssessmentLibrary;
using Microsoft.Practices.Prism.Mvvm;

namespace Liquid.ViewModels
{
    public class ContractDataViewModel : BindableBase
    {
        private ContractData _model;

        public ContractData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value); 
                OnPropertyChanged(() => Expiration);
                OnPropertyChanged(() => Volatility);
                OnPropertyChanged(() => VolChange);
                OnPropertyChanged(() => TickChange);
                OnPropertyChanged(() => ReferenceFuture);
            }
        }

        public DateTime? Expiration{ get { return Model?.Expiration; } }

        public double? Volatility { get { return Model?.Volatility; } }

        public double? VolChange { get { return Model?.VolChange; } }

        public double? TickChange { get { return Model?.TickChange; } }

        public double? ReferenceFuture { get { return Model?.ReferenceFuture; } }

        public ContractDataViewModel(ContractData model)
        {
            Model = model;
        }

        public double ToPercentage(double data, int decimals)
        {
            return Math.Round(100 * data, decimals);
        }
    }
}
