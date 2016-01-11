using Automate.Common;
using Automate.Common.ViewModels;
using Automate.Player;
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

namespace Automate.Spike
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this._MainViewModel = new MainViewModel();
            this.DataContext = _MainViewModel;
        }

        private MainViewModel _MainViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MouseInput.Move(-100, 100);
        }
    }
}
