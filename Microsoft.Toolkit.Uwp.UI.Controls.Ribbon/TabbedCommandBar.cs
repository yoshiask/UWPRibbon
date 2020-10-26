using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class TabbedCommandBar : Control
    {
        public TabbedCommandBar()
        {
            DefaultStyleKey = typeof(TabbedCommandBar);
            //Items.VectorChanged += Items_VectorChanged;
            RibbonItems.Add(new TabbedCommandBarItem()
            {
                Label = "Home"
            });
            RibbonItems.Add(new TabbedCommandBarItem()
            {
                Label = "Insert"
            });
        }

        private void Items_VectorChanged(Windows.Foundation.Collections.IObservableVector<object> sender, Windows.Foundation.Collections.IVectorChangedEventArgs @event)
        {
            // TOOD: Allow direct setting of the Content property by automatically
            // setting this property when the content changes
            //RibbonItemsSource.Clear();
            //foreach (object tab in sender)
            //    RibbonItems.Add(sender as TabbedCommandBarItem);
        }
        
        public static readonly DependencyProperty RibbonItemsProperty = DependencyProperty.Register(
            nameof(RibbonItems),
            typeof(ObservableCollection<TabbedCommandBarItem>),
            typeof(TabbedCommandBar),
            new PropertyMetadata(new ObservableCollection<TabbedCommandBarItem>())
        );
        public ObservableCollection<TabbedCommandBarItem> RibbonItems
        {
            get => (ObservableCollection<TabbedCommandBarItem>)GetValue(RibbonItemsProperty);
            set => SetValue(RibbonItemsProperty, value);
        }
    }
}
