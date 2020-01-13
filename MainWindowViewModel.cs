using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
  public class MainWindowViewModel
  {
    public ObservableCollection<IListItem> Items { get; } = new ObservableCollection<IListItem>();

    public DataTemplateSelector ItemTemplateSelector { get; }

    public MainWindowViewModel()
    {
      Items = new ObservableCollection<IListItem>(new List<IListItem>
      {
        new SomeListItem { Color = Brushes.Yellow, Label = "Item One" },
        new SomeOtherListItem { Description = "Some useless description for item two", Label = "Item Two" },
        new SomeListItem { Color = Brushes.Yellow, Label = "Item Three" },
        new SomeOtherListItem { Description = "Some useless description for item four", Label = "Item Four" }
      });

      var factory = new ItemTemplateFactory();
      factory.Register(typeof(SomeListItem), (DataTemplate)Application.Current.FindResource("SomeListItem_Template"));
      factory.Register(typeof(SomeOtherListItem), (DataTemplate)Application.Current.FindResource("SomeOtherListItem_Template"));

      ItemTemplateSelector = new ItemTemplateSelector(factory);
    }
  }
}
