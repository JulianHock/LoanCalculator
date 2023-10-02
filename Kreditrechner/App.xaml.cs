using Kreditrechner.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kreditrechner
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {


    #region Properties

    private static App _app;
    public MainWindowViewModel MainWindowViewModel { get; private set; }
    public LoanScenarioViewModel LoanScenarioViewModel { get; set; }
    public InstallmentPlanViewModel InstallmentPlanViewModel { get; set;}
    public UnscheduledPaymentViewModel UnscheduledPaymentViewModel { get; set; }
    public UnscheduledPaymentPlanViewModel UnscheduledPaymentPlanViewModel { get; set; }

    #endregion


    public App() : base() 
    {
      _app = this;
      MainWindowViewModel = new MainWindowViewModel();
      LoanScenarioViewModel = new LoanScenarioViewModel();
      InstallmentPlanViewModel = new InstallmentPlanViewModel();
      UnscheduledPaymentViewModel = new UnscheduledPaymentViewModel();
      UnscheduledPaymentPlanViewModel = new UnscheduledPaymentPlanViewModel();
    }

    public static App Get()
    {
      return _app;
    }

  }
}
