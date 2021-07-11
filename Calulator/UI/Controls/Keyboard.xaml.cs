using System.Windows;
using System.Windows.Controls;

namespace Calulator.UI.Controls
{
    /// <summary>
    /// Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : UserControl
    {
        public Keyboard()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler KeyClick;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] button = sender.ToString().Split();
            KeyClick?.Invoke(button[1], e);
        }
    }
}
