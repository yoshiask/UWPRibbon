using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonButton : Button
    {
        private StackPanel contentPanel;
        private TextBlock labelTextBlock;

        public RibbonButton()
        {
            this.DefaultStyleKey = typeof(RibbonButton);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.GetTemplateChild("ContentPanel") is StackPanel sp)
                this.contentPanel = sp;

            if (this.GetTemplateChild("LabelBlock") is TextBlock tb)
                this.labelTextBlock = tb;
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(IconElement), typeof(RibbonButton), new PropertyMetadata(new SymbolIcon(Symbol.Add)));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(RibbonButton), new PropertyMetadata(string.Empty, OnLabelValueChanged));

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact", typeof(bool), typeof(RibbonButton), new PropertyMetadata(default(bool), OnIsCompactChanged));

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

        private static void OnLabelValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RibbonButton self && e.NewValue is string labelText && self.labelTextBlock != null)
            {
                self.labelTextBlock.Visibility = string.IsNullOrEmpty(labelText)
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }
        }

        private static void OnIsCompactChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RibbonButton self && e.NewValue is bool val && self.contentPanel != null)
            {
                self.contentPanel.HorizontalAlignment = val
                    ? HorizontalAlignment.Left
                    : HorizontalAlignment.Center;

                self.contentPanel.Orientation = val
                    ? Orientation.Horizontal
                    : Orientation.Vertical;
            }
        }
    }
}
