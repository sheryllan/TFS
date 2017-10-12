using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Liquid.AssessmentLibrary;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;

namespace Liquid.ViewModels
{
    public class FinancialDataViewModel : BindableBase
    {
        private FinancialData _model;
        private ObservableCollection<PricingSpecViewModel> _pricingSpecRows;
        private PricingSpecViewModel _selectedPricingSpec;

        public FinancialData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value);
                if(_model == null) return;
                OnPropertyChanged(() => TimeStamp);
                PricingSpecRows = 
            }
        }

        public DateTime? TimeStamp { get { return Model?.TimeStamp; } }

        public ObservableCollection<PricingSpecViewModel> PricingSpecRows
        {
            get { return _pricingSpecRows; }
            set { SetProperty(ref _pricingSpecRows, value); }
        }

        public PricingSpecViewModel SelectedPricingSpec
        {
            get { return _selectedPricingSpec; }
            set { SetProperty(ref _selectedPricingSpec, value); }
        }

        public double Td { get; set; }

        public FinancialDataViewModel(FinancialData model)
        {
            Model = model;
            Td = -0.128;
        }

        public void UpdatePriceSpecRows(IEnumerable<PricingSpecData> dataRows)
        {
            foreach (var row in PricingSpecRows)
            {
                bool found = false;
                foreach (var data in dataRows)
                {
                    found = row.IsPricingSpec(data);
                    if (found)
                    {

                        break;
                    }
                }
                if(found)
            }
        }

    }
}
