using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class TabbedCommandBar : ItemsControl
    {
        public TabbedCommandBar()
        {
            DefaultStyleKey = typeof(TabbedCommandBar);
            Items.VectorChanged += Items_VectorChanged;
        }

        private void Items_VectorChanged(Windows.Foundation.Collections.IObservableVector<object> sender, Windows.Foundation.Collections.IVectorChangedEventArgs @event)
        {
            // TOOD: Allow direct setting of the Content property by automatically
            // setting this property when the content changes
            RibbonItemsSource.Clear();
            foreach (object tab in sender)
                RibbonItemsSource.Add(sender as TabbedCommandBarItem);
        }
        
        public static readonly DependencyProperty RibbonItemsSourceProperty = DependencyProperty.Register(
            "RibbonItemsSource", typeof(ObservableCollection<TabbedCommandBarItem>), typeof(TabbedCommandBar), new PropertyMetadata(new ObservableCollection<TabbedCommandBarItem>())
        );
        public ObservableCollection<TabbedCommandBarItem> RibbonItemsSource
        {
            get => (ObservableCollection<TabbedCommandBarItem>)GetValue(RibbonItemsSourceProperty);
            set => SetValue(RibbonItemsSourceProperty, value);
        }
    }
}
