using System.Windows;
using System.Windows.Media;

namespace HalloRessourcen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Resources["farbe"] = new SolidColorBrush(Colors.Aquamarine);
        }
    }
}
