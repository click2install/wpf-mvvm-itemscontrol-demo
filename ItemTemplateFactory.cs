using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
  public class ItemTemplateFactory : DataTemplateSelector
  {
    private readonly IDictionary<Type, DataTemplate> _registry;

    public ItemTemplateFactory() => _registry = new Dictionary<Type, DataTemplate>();

    public void Register(Type type, DataTemplate template) => _registry.Add(type, template);

    public DataTemplate Create(Type type) => _registry.ContainsKey(type) ? _registry[type] : null;
  }
}
