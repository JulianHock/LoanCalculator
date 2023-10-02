using Kreditrechner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.ViewModel
{
  public class UnscheduledPaymentPlanViewModel : BaseViewModel
  {
    #region Properties

    private UnscheduledPaymentEntry _selectedUnscheduledPayment;
    public UnscheduledPaymentEntry SelectedUnscheduledPayment
    {
      get => _selectedUnscheduledPayment;
      set
      {
        if (_selectedUnscheduledPayment != value)
        {
          _selectedUnscheduledPayment = value;
          OnPropertyChanged();
        }
      }
    }

    private ObservableCollection<UnscheduledPaymentEntry> _unscheduledPayments = new ObservableCollection<UnscheduledPaymentEntry>();
    public ObservableCollection<UnscheduledPaymentEntry> UnscheduledPayments
    {
      get => _unscheduledPayments;
      set
      {
        if (_unscheduledPayments != value)
        {
          _unscheduledPayments = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion
  }
}
