using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonButton : Button
    {
        public RibbonButton()
        {
            this.DefaultStyleKey = typeof(RibbonButton);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(IconElement), typeof(RibbonButton), new PropertyMetadata(new SymbolIcon(Symbol.Add)));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(RibbonButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact", typeof(bool), typeof(RibbonButton), new PropertyMetadata(default(bool)));

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
