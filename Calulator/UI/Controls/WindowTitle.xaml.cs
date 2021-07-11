using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calulator.UI.Controls
{
    /// <summary>
    /// Interaction logic for WindowTitle.xaml
    /// </summary>
    public partial class WindowTitle : UserControl
    {
        public WindowTitle()
        {
            InitializeComponent();
        }

        public string Title 
        {
            get { return TitleLabel.Content.ToString(); }
            set { TitleLabel.Content = value; }
        }

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.DragMove();
        }
    }
}
