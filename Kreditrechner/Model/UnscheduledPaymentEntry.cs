using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.Model
{
  public class UnscheduledPaymentEntry : INotifyPropertyChanged
  {
    public UnscheduledPaymentEntry(int month, decimal amount)
    {
      Month = month;
      Amount = amount;
    }
    public int Month { get; set; }

    private decimal _amount;
    public decimal Amount
    {
      get { return _amount; }
      set
      {
        _amount = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
