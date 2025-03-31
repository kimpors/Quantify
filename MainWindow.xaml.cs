using System.Collections.ObjectModel;
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
using Quantify;

namespace Quantify;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ObservableCollection<Item> _items;
    public MainWindow()
    {
        InitializeComponent();

        _items = new ObservableCollection<Item>
        {
            new Item { Name = "Item 1", Count = 0 },
            new Item { Name = "Item 2", Count = 1 },
            new Item { Name = "Item 3", Count = 2 },
            new Item { Name = "Item 3", Count = 2 },
            new Item { Name = "Item 3", Count = 2 },
            new Item { Name = "Item 3", Count = 2 },
            new Item { Name = "Item 3", Count = 2 }
        };

        ItemList.ItemsSource = _items;
    }
    private void Add(object sender, RoutedEventArgs e)
    {
        _items.Add(new Item { Name = "hello", Count = 0 });
    }
    private void Remove(object sender, RoutedEventArgs e)
    {
        _items.Remove(ItemList.SelectedItem as Item);
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