using Kreditrechner.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.IO;
using Kreditrechner.Constants;
using Kreditrechner.View;

namespace Kreditrechner.ViewModel
{

  public class MainWindowViewModel : BaseViewModel
  {
    public DelegateCommand SaveCommand { get; set; }
    public DelegateCommand LoadCommand { get; set; }
    
    public DelegateCommand MinimumRepaymentCommand { get; set; }

    public event EventHandler MinimumRepaymentEvent;

    public MainWindowViewModel()
    {
      SaveCommand = new DelegateCommand(Save);
      LoadCommand = new DelegateCommand(Load);
      
      MinimumRepaymentCommand = new DelegateCommand(_ =>
      {
        MinimumRepaymentEvent?.Invoke(this, EventArgs.Empty);
      });
    }

    

    private void Save(object obj)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog
      {
        Filter = "Kreditrechner file (*.kr)|*.kr",
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        FileName = "Kreditrechnung",
      };

      if (saveFileDialog.ShowDialog() == true)
      {
        StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
        writer.WriteLine(Strings.LoanAmount + "=" + App.Get().LoanScenarioViewModel.LoanAmount);
        writer.WriteLine(Strings.Interest + "=" + App.Get().LoanScenarioViewModel.Interest);

        if (App.Get().LoanScenarioViewModel.IsRate)
        {
          writer.WriteLine(Strings.Rate + "=" + App.Get().LoanScenarioViewModel.Rate);
          writer.WriteLine(Strings.Setting + "=" + Strings.Rate);
        }

        else if (App.Get().LoanScenarioViewModel.IsTerm)
        {
          writer.WriteLine(Strings.Term + "=" + App.Get().LoanScenarioViewModel.Term);
          writer.WriteLine(Strings.Setting + "=" + Strings.Term);
        }

        foreach (var unscheduledPayment in App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments)
        {
          writer.WriteLine(Strings.UnscheduledPayment + "=" + unscheduledPayment.Month + "|" + unscheduledPayment.Amount);
        }

        writer.Close();
      }
    }

    private void Load(object obj)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog
      {
        Filter = "Kreditrechner file (*.kr)|*.kr",
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        FileName = "Kreditrechnung",
      };
      if (openFileDialog.ShowDialog() == true)
      {
        App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.Clear();
        StreamReader reader = new StreamReader(openFileDialog.FileName);
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var parts = line.Split('=');
          switch (parts[0])
          {
            case Strings.LoanAmount:
              App.Get().LoanScenarioViewModel.LoanAmount = Convert.ToDecimal(parts[1]);
              break;
            case Strings.Interest:
              App.Get().LoanScenarioViewModel.Interest = Convert.ToDecimal(parts[1]);
              break;
            case Strings.Rate:
              App.Get().LoanScenarioViewModel.Rate = Convert.ToDecimal(parts[1]);
              break;
            case Strings.Term:
              App.Get().LoanScenarioViewModel.Term = Convert.ToDecimal(parts[1]);
              break;
            case Strings.Setting:
              if (parts[1] == Strings.Rate)
              {
                App.Get().LoanScenarioViewModel.IsRate = true;
                App.Get().LoanScenarioViewModel.IsTerm = false;
              }
              else if (parts[1] == Strings.Term)
              {
                App.Get().LoanScenarioViewModel.IsTerm = true;
                App.Get().LoanScenarioViewModel.IsRate = false;
              }
              break;
            case Strings.UnscheduledPayment:
              var sondertilgungParts = parts[1].Split('|');
              App.Get().UnscheduledPaymentPlanViewModel.UnscheduledPayments.Add(new UnscheduledPaymentEntry(Convert.ToInt32(sondertilgungParts[0]), Convert.ToDecimal(sondertilgungParts[1])));
              break;
          }
        }

        reader.Close();
        App.Get().LoanScenarioViewModel.Calculate(null);
      }
    }
  }
}
