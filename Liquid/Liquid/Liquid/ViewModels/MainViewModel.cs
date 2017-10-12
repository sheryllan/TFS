using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Liquid.AssessmentLibrary;
using System.Windows;
using Microsoft.Practices.Prism.Mvvm;

namespace Liquid.ViewModels
{
    public class MainViewModel : BindableBase, IDisposable
    {
        public DataSource DataSource { get; set; }
        public FinancialDataViewModel FinancialData { get; set; }

        public MainViewModel()
        {
            DataSource = new DataSource();
            FinancialData = new FinancialDataViewModel(null);
            DataSource.SubscribeWithWPFSynchronization(UpdateFinancialData, Application.Current.MainWindow);
        }

        public void UpdateFinancialData(FinancialData data)
        {
            FinancialData.Model = data;
        }

        public void Dispose()
        {
            DataSource?.Dispose();
        }
    }
}
