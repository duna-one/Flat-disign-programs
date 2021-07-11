using System.Windows;

namespace Calulator
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

        private void Keyboard_KeyClick(object sender, RoutedEventArgs e)
        {
            switch (sender.ToString())
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    OutPutTextbox.AppendText(sender.ToString());
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    if (OutPutTextbox.Text.Length != 0 &&
                        OutPutTextbox.Text[^1] != '+' &&
                        OutPutTextbox.Text[^1] != '-' &&
                        OutPutTextbox.Text[^1] != '*' &&
                        OutPutTextbox.Text[^1] != '/')
                    {
                        OutPutTextbox.AppendText(sender.ToString());
                    }
                    break;
                case ",":
                    if (OutPutTextbox.Text.Length != 0 && CanInputSemi())
                    {
                        OutPutTextbox.AppendText(",");
                    }
                    break;
                case "DEL":
                    if (OutPutTextbox.Text.Length == 0) { return; }
                    OutPutTextbox.Text = OutPutTextbox.Text.Remove(OutPutTextbox.Text.Length - 1);
                    break;
                case "C":
                    OutPutTextbox.Clear();
                    break;
                case "+/-":
                    if (OutPutTextbox.Text.Length == 0) { return; }
                    if (OutPutTextbox.Text[0] != '-')
                    {
                        OutPutTextbox.Text = "-" + OutPutTextbox.Text;
                    }
                    else
                    {
                        OutPutTextbox.Text = OutPutTextbox.Text[1..];
                    }
                    break;
                case "%":
                    if (OutPutTextbox.Text.Length == 0) { return; }
                    CalcPercent();
                    break;
                case "=":
                    if(OutPutTextbox.Text.Length == 0) { return; }
                    CalcResult();                    
                    break;

                default:
                    MessageBox.Show(sender.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void CalcPercent()
        {

        }

        private void CalcResult()
        {

        }

        private bool CanInputSemi()
        {
            if (OutPutTextbox.Text[^1] == ',')
            {
                return false;
            }

            if (!OutPutTextbox.Text.Contains('+') &&
                !OutPutTextbox.Text.Contains('-') &&
                !OutPutTextbox.Text.Contains('*') &&
                !OutPutTextbox.Text.Contains('/'))
            {
                if (!OutPutTextbox.Text.Contains(','))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            string buf = OutPutTextbox.Text;
            while (buf[^1] != '+' &&
                   buf[^1] != '-' &&
                   buf[^1] != '*' &&
                   buf[^1] != '/')
            {
                if (buf[^1] == ',')
                {
                    return false;
                }

                buf = buf[0..^1];
            }
            return true;
        }
    }
}
