using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonDropDownButton : DropDownButton
    {
        private StackPanel contentPanel;
        private TextBlock labelTextBlock;

        public RibbonDropDownButton()
        {
            this.DefaultStyleKey = typeof(RibbonDropDownButton);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.GetTemplateChild("PART_ContentPanel") is StackPanel sp)
                this.contentPanel = sp;

            if (this.GetTemplateChild("PART_LabelBlock") is TextBlock tb)
                this.labelTextBlock = tb;
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof(IconElement), typeof(RibbonDropDownButton), new PropertyMetadata(new SymbolIcon(Symbol.Add)));

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(RibbonDropDownButton), new PropertyMetadata(string.Empty, OnLabelValueChanged));

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact", typeof(bool), typeof(RibbonDropDownButton), new PropertyMetadata(false, OnIsCompactChanged));

        public bool IsCompact
        {
            get => (bool)GetValue(IsCompactProperty);
            set => SetValue(IsCompactProperty, value);
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public IconElement Icon
        {
            get => (IconElement) GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }


        private static void OnLabelValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RibbonDropDownButton self && e.NewValue is string labelText && self.labelTextBlock != null)
            {
                self.labelTextBlock.Visibility = string.IsNullOrEmpty(labelText)
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            }
        }

        private static void OnIsCompactChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RibbonDropDownButton self && e.NewValue is bool val && self.contentPanel != null)
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
