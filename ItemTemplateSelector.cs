using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
  public class ItemTemplateSelector : DataTemplateSelector
  {
    private readonly ItemTemplateFactory _factory;

    public ItemTemplateSelector(ItemTemplateFactory factory) => _factory = factory ?? throw new ArgumentNullException(nameof(factory));

    public override DataTemplate SelectTemplate(object item, DependencyObject container) => _factory.Create(item.GetType()) ?? base.SelectTemplate(item, container);
  }
}
