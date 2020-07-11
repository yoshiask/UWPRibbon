using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public sealed class RibbonSplitButton : SplitButton, IRibbonButton
    {
        public RibbonSplitButton()
        {
            this.DefaultStyleKey = typeof(RibbonSplitButton);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(IconElement),
            typeof(RibbonDropDownButton),
            new PropertyMetadata(new SymbolIcon(Symbol.Add))
        );
        public IconElement Icon {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label",
            typeof(string),
            typeof(RibbonDropDownButton),
            new PropertyMetadata("")
        );
        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact",
            typeof(bool),
            typeof(RibbonDropDownButton),
            new PropertyMetadata(false)
        );
        public bool IsCompact {
            get { return (bool)GetValue(IsCompactProperty); }
            set { SetValue(IsCompactProperty, value); }
        }
    }
}
