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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kreditrechner.View
{
  /// <summary>
  /// Interaction logic for SondertilgungView.xaml
  /// </summary>
  public partial class SondertilgungView : UserControl
  {
    public SondertilgungView()
    {
      InitializeComponent();
      DataContext = App.Get().UnscheduledPaymentViewModel;
    }

    private void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      var textBox = (TextBox)sender;
      Dispatcher.BeginInvoke(new Action(() => textBox.SelectAll()));
    }

    private void SetButtonFocus(object sender, RoutedEventArgs e)
    {
      var button = (Button)sender;
      button.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
    }
  }
}
