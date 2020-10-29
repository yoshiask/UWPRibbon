using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class TabbedCommandBar : ItemsControl
    {
        private NavigationView RibbonNavigationView = null;
        private ContentControl RibbonContent = null;

        // This should probably be made public at some point
        private TabbedCommandBarItem SelectedTab { get; set; }

        public TabbedCommandBar()
        {
            DefaultStyleKey = typeof(TabbedCommandBar);
            Items.VectorChanged += Items_VectorChanged;
            //RibbonItems.Add(new TabbedCommandBarItem()
            //{
            //    Label = "Home"
            //});
            //RibbonItems.Add(new TabbedCommandBarItem()
            //{
            //    Label = "Insert"
            //});
        }

        private void Items_VectorChanged(Windows.Foundation.Collections.IObservableVector<object> sender, Windows.Foundation.Collections.IVectorChangedEventArgs @event)
        {
            // TOOD: Allow direct setting of the Content property by automatically
            // setting this property when the content changes
            //RibbonItemsSource.Clear();
            //foreach (object tab in sender)
            //    RibbonItems.Add(sender as TabbedCommandBarItem);
        }
        
        // Should I be using a custom property for ribbon items, or just use the Items property from ItemsControl?
        // And does this need to be an ObservableCollection, or is IList enough?

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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Should probably put the part name in a const string

            // Get RibbonContent first, since setting SelectedItem requires it
            RibbonContent = GetTemplateChild("PART_RibbonContent") as ContentControl;

            RibbonNavigationView = GetTemplateChild("PART_RibbonNavigationView") as NavigationView;
            if (RibbonNavigationView != null)
            {
                RibbonNavigationView.SelectionChanged += RibbonNavigationView_SelectionChanged;
                RibbonNavigationView.SelectedItem = RibbonNavigationView.MenuItems.FirstOrDefault();
            }
        }

        private void RibbonNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is TabbedCommandBarItem item)
            {
                SelectedTab = item;
            }
            else if (args.SelectedItem is NavigationViewItem navItem)
            {
                // This code is a hack and is only temporary, because I can't get binding to work.
                // RibbonContent might be null here, there should be a check

                // This actually will throw an exception saying that the elemnt already has a parent. I suspect that the parent is
                // this TabbedCommandBar, so it can't be set as the content here. How do I get around this?
                //RibbonContent.Content = Items[System.Math.Min(Items.Count - 1, RibbonNavigationView.MenuItems.IndexOf(navItem))];
            }
        }
    }
}
