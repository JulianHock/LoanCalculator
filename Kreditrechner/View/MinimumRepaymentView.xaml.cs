using Kreditrechner.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kreditrechner.View
{
  /// <summary>
  /// Interaction logic for MindesttilgungView.xaml
  /// </summary>
  public partial class MindesttilgungView : Window
  {
    public MindesttilgungView()
    {
      InitializeComponent();
      DataContext = new MinimumRepaymentViewModel();
    }

    private void SetButtonFocus(object sender, RoutedEventArgs e)
    {
      var button = (Button)sender;
      button.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      var textBox = (TextBox)sender;
      Dispatcher.BeginInvoke(new Action(() => textBox.SelectAll()));
    }
  }
}
