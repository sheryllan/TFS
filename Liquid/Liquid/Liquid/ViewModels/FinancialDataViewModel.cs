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
                OnPropertyChanged(() => TimeStamp);
                UpdatePriceSpecRows();
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

        public FinancialDataViewModel(FinancialData model)
        {
            Model = model;
        }

        public void UpdatePriceSpecRows()
        {
            if (Model == null)
            {
                PricingSpecRows = null;
                return;
            }
            if(PricingSpecRows == null)
                PricingSpecRows = new ObservableCollection<PricingSpecViewModel>();
            else
            {
                foreach (var row in PricingSpecRows)
                {
                    bool found = false;
                    foreach (var data in Model.PricingSpecRows)
                    {
                        found = row.HasSamePricingSpec(data);
                        if (!found) continue;
                        row.Model = data;
                        break;
                    }
                    if (!found) PricingSpecRows.Remove(row);
                }
            }

            var newRows = Model.PricingSpecRows.Where(x => !PricingSpecRows.Any(y => y.HasSamePricingSpec(x)));
            PricingSpecRows.AddRange(newRows.Select(x => new PricingSpecViewModel(x)));

        }

    }
}
