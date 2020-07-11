using Windows.Foundation;
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

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(TabbedCommandBarItem), new PropertyMetadata("")
        );
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

    }
}
