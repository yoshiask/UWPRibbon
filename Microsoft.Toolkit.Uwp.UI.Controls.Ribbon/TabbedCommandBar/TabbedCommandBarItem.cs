using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class TabbedCommandBarItem : CommandBar
    {
        private ItemsControl PrimaryItemsControl;
        private Button MoreButton;

        public TabbedCommandBarItem()
        {
            DefaultStyleKey = typeof(TabbedCommandBarItem);
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(TabbedCommandBarItem), new PropertyMetadata("Test")
        );
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(
            "Footer", typeof(UIElement), typeof(TabbedCommandBarItem), new PropertyMetadata(new Grid())
        );
        public UIElement Footer
        {
            get => (UIElement)GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PrimaryItemsControl = GetTemplateChild("PrimaryItemsControl") as ItemsControl;
            if (PrimaryItemsControl != null)
            {
                PrimaryItemsControl.HorizontalAlignment = HorizontalAlignment.Left;
            }

            MoreButton = GetTemplateChild("MoreButton") as Button;
            if (MoreButton != null)
            {
                MoreButton.HorizontalAlignment = HorizontalAlignment.Right;
            }
        }
    }
}
