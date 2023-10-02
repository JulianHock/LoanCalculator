using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.ViewModel
{
  internal class MinimumRepaymentViewModel : BaseViewModel
  {
    #region Properties

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

    private decimal _minimumRepayment = 0.02M;
    public decimal MinimumRepayment
    {
      get => _minimumRepayment;
      set
      {
        if (_minimumRepayment != value)
        {
          _minimumRepayment = value;
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

    private decimal _minimumMonthlyRate = 0;
    public decimal MinimumMonthlyRate
    {
      get => _minimumMonthlyRate;
      set
      {
        if (_minimumMonthlyRate != value)
        {
          _minimumMonthlyRate = value;
          OnPropertyChanged();
        }
      }
    }

    #endregion

    public DelegateCommand CalculateCommand { get; set; }

    public MinimumRepaymentViewModel()
    {
      CalculateCommand = new DelegateCommand(Calculate);
    }

    private void Calculate(object obj)
    {
      var interestMonth = (LoanAmount * Interest) / 12;
      var minimumRepayment = (LoanAmount * 0.02M) / 12M;

      MinimumMonthlyRate = Math.Round(minimumRepayment + interestMonth + 1);
    }
  }
}
