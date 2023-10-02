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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kreditrechner.View
{
  /// <summary>
  /// Interaction logic for RatenplanView.xaml
  /// </summary>
  public partial class RatenplanView : UserControl
  {
    public event EventHandler RatenplanEintragSelectedEvent;

    public RatenplanView()
    {
      InitializeComponent();
      var viewModel = App.Get().InstallmentPlanViewModel;
      DataContext = viewModel;
      RatenplanEintragSelectedEvent += (sender, eventargs) => viewModel.RateSelected();
    }

    private void RatenplanSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      RatenplanEintragSelectedEvent?.Invoke(null, null);
    }
  }
}
