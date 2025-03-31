using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace Quantify;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ObservableCollection<Item> _items;
    private const string folderPath = "C:\\ProgramData\\Quantify";
    private const string filePath = folderPath + "\\data.dat";
    public MainWindow()
    {
        InitializeComponent();
        _items = new ObservableCollection<Item>();

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        else if (File.Exists(filePath))
        {
            string json = Encoding.UTF8.GetString(File.ReadAllBytes(filePath));
            _items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(json);
        }

        ItemList.ItemsSource = _items;
    }
    private void Add(object sender, RoutedEventArgs e)
    {
        InputDialog dialog = new();
        if (dialog.ShowDialog() ?? false)
        {
            _items.Add(new Item { Name = dialog.Result, Count = 0 });
        }
    }
    private void Rename(object sender, RoutedEventArgs e)
    {
        InputDialog dialog = new();
        Item item = ItemList.SelectedItem as Item; 

        if (item == null) return;

        if (dialog.ShowDialog() ?? false)
        {
            item.Name = dialog.Result;
        }
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
        string json = JsonConvert.SerializeObject(_items);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(json));
        Close();
    }
    private void Drag(object sender, RoutedEventArgs e)
    {
        DragMove();
    }
}