﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Microsoft.Toolkit.Uwp.UI.Controls.Ribbon
{
    public class RibbonButton : Button
    {
        public RibbonButton()
        {
            this.DefaultStyleKey = typeof(RibbonButton);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(IconElement),
            typeof(RibbonButton),
            new PropertyMetadata(new SymbolIcon(Symbol.Add))
        );
        public IconElement Icon {
            get { return (IconElement)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label",
            typeof(string),
            typeof(RibbonButton),
            new PropertyMetadata("")
        );
        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
            "IsCompact",
            typeof(bool),
            typeof(RibbonButton),
            new PropertyMetadata(false)
        );
        public bool IsCompact {
            get { return (bool)GetValue(IsCompactProperty); }
            set { SetValue(IsCompactProperty, value); }
        }
    }
}
