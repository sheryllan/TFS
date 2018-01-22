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
    public class FinancialDataViewModel : BaseViewModel
    {
        private FinancialData _model;
        private ObservableCollection<PricingSpecViewModel> _pricingSpecRows;
        private PricingSpecViewModel _selectedPricingSpec;
        private List<Action> _modelActions;

        public FinancialData Model
        {
            get { return _model; }
            set
            {
                SetProperty(ref _model, value);
                Notify(_modelActions);
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
            _modelActions = new List<Action>
            {
                () => OnPropertyChanged(() => TimeStamp),
                UpdatePriceSpecRows
            };
        }

        public void UpdatePriceSpecRows()
        {
            if (Model == null)
            {
                PricingSpecRows = null;
                return;
            }

            foreach (var row in PricingSpecRows = PricingSpecRows?? new ObservableCollection<PricingSpecViewModel>())
            {
                var foundRow = Model.PricingSpecRows.FirstOrDefault(x => row.IsSamePricingSpec(x));
                row.Model = foundRow;
            }
            var rows = PricingSpecRows.Where(x => x.Model != null);
            var newRows = Model.PricingSpecRows.Where(x => !rows.Any(y => y.IsSamePricingSpec(x)));
            PricingSpecRows = new ObservableCollection<PricingSpecViewModel>(rows);
            PricingSpecRows.AddRange(newRows.Select(x => new PricingSpecViewModel(x)));

        }

    }
}
