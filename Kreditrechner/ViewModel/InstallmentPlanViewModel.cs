using Kreditrechner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.ViewModel
{
  public class InstallmentPlanViewModel : BaseViewModel
  {
    #region Properties

    private ObservableCollection<InstallmentPlanEntry> _installmentPlan = new ObservableCollection<InstallmentPlanEntry>();
    public ObservableCollection<InstallmentPlanEntry> InstallmentPlan
    {
      get => _installmentPlan;
      set
      {
        if (_installmentPlan != value)
        {
          _installmentPlan = value;
          OnPropertyChanged();
        }
      }
    }

    private InstallmentPlanEntry _selectedInstallmentPlanEntry;
    public InstallmentPlanEntry SelectedInstallmentPlanEntry
    {
      get => _selectedInstallmentPlanEntry;
      set
      {
        if (_selectedInstallmentPlanEntry != value)
        {
          _selectedInstallmentPlanEntry = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion

    public void RateSelected()
    {
      if (SelectedInstallmentPlanEntry != null)
      {
        App.Get().UnscheduledPaymentViewModel.UnscheduledPaymentMonth = SelectedInstallmentPlanEntry.Month.ToString();
      }
    }

  }
}
