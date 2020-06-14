using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonColumn : ListViewBase
    {
        public RibbonColumn()
        {
            this.DefaultStyleKey = typeof(RibbonColumn);
        }

        public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register(
            "Spacing", typeof(double), typeof(RibbonColumn), new PropertyMetadata(1.0));

        public double Spacing 
        {
            get => (double)GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }
    }
}
