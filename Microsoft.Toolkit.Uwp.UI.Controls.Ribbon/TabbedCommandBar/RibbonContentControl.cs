using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonContentControl : Page
    {
        public RibbonContentControl()
        {
            this.DefaultStyleKey = typeof(RibbonContentControl);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is UIElement element)
            {
                Content = element;
            }
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // The TabbedCommandBarItem can't be used again if it is the content of another element.
            // Setting Content to null would fix this, but then the slide animations aren't as smooth
            // because the previous CommandBar disappears as soon as the animation starts.

            // To avoid this, render the contents of the page to a static image and set the content
            // to the rendered control.

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(Content);
            Content = new Image() { Source = renderTargetBitmap };
        }
    }
}
