using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonGroup : ListViewBase
    {
        public RibbonGroup()
        {
            this.DefaultStyleKey = typeof(RibbonGroup);
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(RibbonGroup), new PropertyMetadata(string.Empty));

        public string Label 
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
    }
}
