using System.ComponentModel;
namespace Quantify;

public class Item : INotifyPropertyChanged
{
    private string _name;
    private int _count;

    public string Name 
    { 
        get { return _name; }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

    }
    public int Count 
    { 
        get { return _count; }
        set
        {
            if (_count != value)
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}