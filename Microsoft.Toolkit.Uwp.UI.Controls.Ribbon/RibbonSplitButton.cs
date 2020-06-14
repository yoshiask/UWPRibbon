using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonSplitButton : Control
    {
        public RibbonSplitButton()
        {
            this.DefaultStyleKey = typeof(RibbonSplitButton);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(IconElement), typeof(RibbonDropDownButton), new PropertyMetadata(new SymbolIcon(Symbol.Add)));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(RibbonDropDownButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact", typeof(bool), typeof(RibbonDropDownButton), new PropertyMetadata(default(bool)));

        public IconElement Icon 
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public string Label 
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public bool IsCompact 
        {
            get => (bool)GetValue(IsCompactProperty);
            set => SetValue(IsCompactProperty, value);
        }
    }
}
