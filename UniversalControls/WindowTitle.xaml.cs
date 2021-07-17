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
            get => TitleLabel.Content.ToString();
            set => TitleLabel.Content = value;
        }

        public Visibility MaxButtonVisibility
        {
            get => MaxiButton.Visibility;
            set => MaxiButton.Visibility = value;
        }

        private void MiniButton_Click(object sender, RoutedEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.WindowState = WindowState.Minimized;
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.WindowState = myWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            Window myWindow = Window.GetWindow(this);
            myWindow.DragMove();
        }
    }
}
