using Kreditrechner.Constants;
using Kreditrechner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kreditrechner.ViewModel
{
  public class UnscheduledPaymentViewModel : BaseViewModel
  {
    #region Properties

    public DelegateCommand AddUnscheduledPaymentCommand { get; set; }
    public DelegateCommand RemoveUnscheduledPaymentCommand { get; set; }

    private string _unscheduledPaymentMonth = "";
    public string UnscheduledPaymentMonth
    {
      get => _unscheduledPaymentMonth;
      set
      {
        if (_unscheduledPaymentMonth != value)
        {
          _unscheduledPaymentMonth = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _unscheduledPaymentAmount = 0;
    public decimal UnscheduledPaymentAmount
    {
      get => _unscheduledPaymentAmount;
      set
      {
        if (_unscheduledPaymentAmount != value)
        {
          _unscheduledPaymentAmount = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion

    public UnscheduledPaymentViewModel()
    {
      AddUnscheduledPaymentCommand = new DelegateCommand(AddUnscheduledPayment);
      RemoveUnscheduledPaymentCommand = new DelegateCommand(RemoveUnscheduledPayment);
    }

    private void AddUnscheduledPayment(object obj)
    {
      if (!int.TryParse(UnscheduledPaymentMonth, out int sondertilgungMonat))
      {
        MessageBox.Show("Kein gültiger Monat für Sondertilgung angegeben!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (UnscheduledPaymentAmount <= 0)
      {
        MessageBox.Show("Kein Betrag für Sondertilgung angegeben!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.Add(new UnscheduledPaymentEntry(sondertilgungMonat, UnscheduledPaymentAmount));
      App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments = new ObservableCollection<UnscheduledPaymentEntry>(App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.OrderBy(x => x.Month));
      UnscheduledPaymentMonth = "";
      UnscheduledPaymentAmount = 0;

      if (App.Get().InstallmentPlanViewModel.InstallmentPlan.Any())
      {
        App.Get().LoanScenarioViewModel.Calculate(null);
      }
    }

    private void RemoveUnscheduledPayment(object obj)
    {
      if (App.Get().UnscheduledPaymentPlanViewModel.SelectedUnscheduledPayment == null)
      {
        return;
      }

      App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.Remove(App.Get().UnscheduledPaymentPlanViewModel.SelectedUnscheduledPayment);

      if (App.Get().InstallmentPlanViewModel.InstallmentPlan.Any())
      {
        App.Get().LoanScenarioViewModel.Calculate(null);
      }
    }
  }
}
