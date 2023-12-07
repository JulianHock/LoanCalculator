using Kreditrechner.Constants;
using Kreditrechner.Model;
using Kreditrechner.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Kreditrechner.ViewModel
{
  public class LoanScenarioViewModel : BaseViewModel
  {
    #region Properties

    public DelegateCommand CalculateCommand { get; set; }

    private decimal _loanAmount = 250000;
    public decimal LoanAmount
    {
      get => _loanAmount;
      set
      {
        if (_loanAmount != value)
        {
          _loanAmount = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _interest = 0.035M;
    public decimal Interest
    {
      get => _interest;
      set
      {
        if (_interest != value)
        {
          _interest = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _rate = 1200;
    public decimal Rate
    {
      get => _rate;
      set
      {
        if (_rate != value)
        {
          _rate = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _term = 0;
    public decimal Term
    {
      get => _term;
      set
      {
        if (_term != value)
        {
          _term = value;
          OnPropertyChanged();
        }
      }
    }

    private Brush _backgroundRate = new SolidColorBrush(Colors.White);
    public Brush BackgroundRate
    {
      get => _backgroundRate;
      set
      {
        if (_backgroundRate != value)
        {
          _backgroundRate = value;
          OnPropertyChanged();
        }
      }
    }

    private bool _isRate = true;
    public bool IsRate
    {
      get => _isRate;
      set
      {
        if (_isRate != value)
        {
          _isRate = value;
          OnPropertyChanged();
        }
        if (_isRate)
        {
          BackgroundRate = new SolidColorBrush(Colors.White);
          BackgroundTerm = new SolidColorBrush(Colors.LightGray);
        }
      }
    }

    private Brush _backgroundTerm = new SolidColorBrush(Colors.LightGray);
    public Brush BackgroundTerm
    {
      get => _backgroundTerm;
      set
      {
        if (_backgroundTerm != value)
        {
          _backgroundTerm = value;
          OnPropertyChanged();
        }
      }
    }

    private bool _isTerm = false;
    public bool IsTerm
    {
      get => _isTerm;
      set
      {
        if (_isTerm != value)
        {
          _isTerm = value;
          OnPropertyChanged();
        }

        if (_isTerm)
        {
          BackgroundTerm = new SolidColorBrush(Colors.White);
          BackgroundRate = new SolidColorBrush(Colors.LightGray);
        }
      }
    }

    private decimal _interestTotal = 0;
    public decimal InterestTotal
    {
      get => _interestTotal;
      set
      {
        if (_interestTotal != value)
        {
          _interestTotal = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _sumTotal = 0;
    public decimal SumTotal
    {
      get => _sumTotal;
      set
      {
        if (_sumTotal != value)
        {
          _sumTotal = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _repaymentAtBegin = 0;
    public decimal RepaymentAtBegin
    {
      get => _repaymentAtBegin;
      set
      {
        if (_repaymentAtBegin != value)
        {
          _repaymentAtBegin = value;
          OnPropertyChanged();
        }
      }
    }

    private Brush _interestDifferenceColor = new SolidColorBrush(Colors.Black);
    public Brush InterestDifferenceColor
    {
      get => _interestDifferenceColor;
      set
      {
        if (_interestDifferenceColor != value)
        {
          _interestDifferenceColor = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _lastInterestTotal = 0;

    private decimal _interestTotalDifference = 0;
    public decimal InterestTotalDifference
    {
      get => _interestTotalDifference;
      set
      {
        if (_interestTotalDifference != value)
        {
          _interestTotalDifference = value;
          OnPropertyChanged();
        }
      }
    }

    private Brush _repaymentDifferenceColor = new SolidColorBrush(Colors.Black);
    public Brush RepaymentDifferenceColor
    {
      get => _repaymentDifferenceColor;
      set
      {
        if (_repaymentDifferenceColor != value)
        {
          _repaymentDifferenceColor = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _lastRepaymentAtBegin = 0;

    private decimal _differenceRepaymentAtBegin = 0;
    public decimal DifferenceRepaymentAtBegin
    {
      get => _differenceRepaymentAtBegin;
      set
      {
        if (_differenceRepaymentAtBegin != value)
        {
          _differenceRepaymentAtBegin = value;
          OnPropertyChanged();
        }
      }
    }

    private Brush _rateDifferenceColor = new SolidColorBrush(Colors.Black);
    public Brush RateDifferenceColor
    {
      get => _rateDifferenceColor;
      set
      {
        if (_rateDifferenceColor != value)
        {
          _rateDifferenceColor = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _lastRate = 0;

    private decimal _differenceRate = 0;
    public decimal DifferenceRate
    {
      get => _differenceRate;
      set
      {
        if (_differenceRate != value)
        {
          _differenceRate = value;
          OnPropertyChanged();
        }
      }
    }

    private Brush _termDifferenceColor = new SolidColorBrush(Colors.Black);
    public Brush TermDifferenceColor
    {
      get => _termDifferenceColor;
      set
      {
        if (_termDifferenceColor != value)
        {
          _termDifferenceColor = value;
          OnPropertyChanged();
        }
      }
    }

    private decimal _lastTerm = 0;

    private decimal _differenceTerm = 0;
    public decimal DifferenceTerm
    {
      get => _differenceTerm;
      set
      {
        if (_differenceTerm != value)
        {
          _differenceTerm = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion


    public LoanScenarioViewModel()
    {
      CalculateCommand = new DelegateCommand(Calculate);
    }

    public void Calculate(object obj)
    {
      App.Get().InstallmentPlanViewModel.InstallmentPlan.Clear();

      if (LoanAmount <= 0)
      {
        MessageBox.Show("Kreditsumme muss größer 0 sein!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (Interest < 0)
      {
        MessageBox.Show("Zins muss größer/gleich 0 sein!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (Term <= 0 && IsTerm)
      {
        MessageBox.Show("Laufzeit muss größer 0 sein!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      if (IsTerm)
      {
        Rate = Math.Round(LoanAmount * (Interest / 12) / (1 - (decimal)Math.Pow((double)(1 + Interest / 12), (double)(-Term * 12))));
        DifferenceTerm = 0;

        if (_lastRate == 0)
        {
          _lastRate = Rate;
        }

        else
        {
          DifferenceRate = Rate - _lastRate;
          if (DifferenceRate > 0)
          {
            RateDifferenceColor = new SolidColorBrush(Colors.Red);
          }

          else if (DifferenceRate < 0)
          {
            RateDifferenceColor = new SolidColorBrush(Colors.Green);
          }

          _lastRate = Rate;
        }

        if (App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.Any())
        {
          MessageBox.Show("Sondertilgungen können nur bei festgelegter Rate berücksichtigt werden!", "Warnung", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
      }

      else
      {
        var interestMonth = (LoanAmount * Interest) / 12;
        var repaymentMonth = Rate - interestMonth;
        var minimumRepayment = (LoanAmount * 0.01M) / 12M;


        if (repaymentMonth < minimumRepayment)
        {
          MessageBox.Show("Rate nicht ausreichend!\nMindestrate für 1% Tilgung: " + Math.Round(minimumRepayment + interestMonth + 1).ToString("c"),
            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          return;
        }

        
      }

      var interestTotal = 0.0M;
      var restLoanAmount = LoanAmount;
      var currentMonth = 1M;

      DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

      dateTime = dateTime.AddMonths(1);

      while (restLoanAmount > 0)
      {
        if (_isRate)
        {
          foreach (var unscheduledPayment in App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments)
          {
            if (unscheduledPayment.Month == currentMonth)
            {
              if (restLoanAmount - unscheduledPayment.Amount < 0)
              {
                unscheduledPayment.Amount = Math.Round(restLoanAmount, 2);
                restLoanAmount = 0;
              }
              else
              {
                restLoanAmount -= unscheduledPayment.Amount;
              }
              App.Get().InstallmentPlanViewModel.InstallmentPlan.Add(new InstallmentPlanEntry(dateTime, (int)currentMonth, restLoanAmount, 0, unscheduledPayment.Amount, Resources.UnscheduledPayment));
            }
          }
        }

        var interestMonth = (restLoanAmount * Interest) / 12;
        var repaymentMonth = Rate - interestMonth;
        interestTotal += interestMonth;

        if (restLoanAmount == 0)
        {
          break;
        }

        if (restLoanAmount - repaymentMonth < 0)
        {
          repaymentMonth = restLoanAmount;
          App.Get().InstallmentPlanViewModel.InstallmentPlan.Add(new InstallmentPlanEntry(dateTime, (int)currentMonth, 0, interestMonth, repaymentMonth, Resources.RateInInstallmentPlan));
          break;
        }

        restLoanAmount -= repaymentMonth;

        App.Get().InstallmentPlanViewModel.InstallmentPlan.Add(new InstallmentPlanEntry(dateTime, (int)currentMonth, restLoanAmount, interestMonth, repaymentMonth, Resources.RateInInstallmentPlan));
        currentMonth++;
        dateTime = dateTime.AddMonths(1);
      }

      InterestTotal = interestTotal;
      SumTotal = LoanAmount + interestTotal;

      if (_lastInterestTotal == 0)
      {
        _lastInterestTotal = InterestTotal;
      }

      else
      {
        InterestTotalDifference = InterestTotal - _lastInterestTotal;
        if (InterestTotalDifference > 0)
        {
          InterestDifferenceColor = new SolidColorBrush(Colors.Red);
        }

        else if (InterestTotalDifference < 0)
        {
          InterestDifferenceColor = new SolidColorBrush(Colors.Green);
        }

        _lastInterestTotal = InterestTotal;
      }

      RepaymentAtBegin = (App.Get().InstallmentPlanViewModel.InstallmentPlan[0].Repayment * 12) / LoanAmount;
      if (_lastRepaymentAtBegin == 0)
      {
        _lastRepaymentAtBegin = RepaymentAtBegin;
      }

      else
      {
        DifferenceRepaymentAtBegin = RepaymentAtBegin - _lastRepaymentAtBegin;
        if (DifferenceRepaymentAtBegin > 0)
        {
          RepaymentDifferenceColor = new SolidColorBrush(Colors.Green);
        }

        else if (DifferenceRepaymentAtBegin < 0)
        {
          RepaymentDifferenceColor = new SolidColorBrush(Colors.Red);
        }

        _lastRepaymentAtBegin = RepaymentAtBegin;
      }

      if (IsRate)
      {
        Term = (currentMonth / 12);
        DifferenceRate = 0;

        if (_lastTerm == 0)
        {
          _lastTerm = Term;
        }

        else
        {
          DifferenceTerm = Term - _lastTerm;
          if (DifferenceTerm > 0)
          {
            TermDifferenceColor = new SolidColorBrush(Colors.Red);
          }

          else if (DifferenceTerm < 0)
          {
            TermDifferenceColor = new SolidColorBrush(Colors.Green);
          }

          _lastTerm = Term;
        }
      }
    }
  }
}
