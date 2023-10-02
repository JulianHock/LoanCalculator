using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.Model
{
  public class InstallmentPlanEntry
  {
    public InstallmentPlanEntry(DateTime date, int month, decimal remainingDebt, decimal interest, decimal repayment, string type)
    {
      Date = date;
      Month = month;
      RemainingDebt = remainingDebt;
      Interest = interest;
      Repayment = repayment;
      Type = type;
    }

    public DateTime Date { get; set; }
    public int Month { get; set; }
    public decimal RemainingDebt { get; set; }
    public decimal Interest { get; set; }
    public decimal Repayment { get; set; }
    public string Type { get; set; }
  }
}
