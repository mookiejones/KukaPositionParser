using CommunityToolkit.Mvvm.DependencyInjection;
using KukaPositionParser.UI.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KukaPositionParser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow 
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = Ioc.Default.GetRequiredService<MainViewModel>();
    }

    private void SaveSettings(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var dataContext = DataContext as MainViewModel;
        OptionsViewModel.Save(dataContext?.Options);
    }
}