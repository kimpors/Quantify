using System.Windows;
using System.Windows.Input;

namespace Quantify;

public partial class InputDialog : Window
{
    public string Result { get; private set; }
    public InputDialog()
    {
        InitializeComponent();
    }

    private void LoadedWindow(object sender, RoutedEventArgs e)
    {
        input.Focus();
    }
    
    private void OkResult(object sneder, RoutedEventArgs e)
    {
        Result = input.Text;
        DialogResult = true;
    }

    private void CancelResult(object sneder, RoutedEventArgs e)
    {
        DialogResult = false;
    }
    private void IsEnter(object sneder, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Result = input.Text;
            DialogResult = true;
        }
    }
    private void Minimize(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    private void Close(object sender, RoutedEventArgs e)
    {
        Close();
    }
    private void Drag(object sender, RoutedEventArgs e)
    {
        DragMove();
    }
}