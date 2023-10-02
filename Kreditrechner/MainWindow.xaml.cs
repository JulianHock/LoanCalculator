using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kreditrechner.View;
using Kreditrechner.ViewModel;

namespace Kreditrechner
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      var viewModel = App.Get().MainWindowViewModel;
      DataContext = viewModel;
      viewModel.MinimumRepaymentEvent += (sender, eventargs) => ShowMinimumRepaymentView();
    }
        

    private void InfoClicked(object sender, RoutedEventArgs e)
    {
      string messageBoxText = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright + "\n" +
        "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      MessageBox.Show(messageBoxText , "Info", MessageBoxButton.OK);
    }

    private void ShowMinimumRepaymentView()
    {
      var win = new MindesttilgungView();
      win.Owner = this;
      win.ShowDialog();
    }
  }
}
