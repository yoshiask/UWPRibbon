using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class TabbedCommandBarItem : CommandBar
    {
        public TabbedCommandBarItem()
        {
            DefaultStyleKey = typeof(TabbedCommandBarItem);
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(TabbedCommandBarItem), new PropertyMetadata("")
        );
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
    }
}
