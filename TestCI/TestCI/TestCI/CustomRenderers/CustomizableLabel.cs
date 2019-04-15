using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestCI.CustomRenderers
{
    public class CustomizableLabel : Label
    {
        public static readonly BindableProperty FontTypeProperty = BindableProperty.Create("FontType", typeof(FontTypes), typeof(CustomizableLabel), FontTypes.HelveticaNeueRegular);
        public FontTypes FontType
        {
            get { return (FontTypes)GetValue(FontTypeProperty); }
            set { SetValue(FontTypeProperty, value); }
        }

        public enum FontTypes
        {
            HelveticaNeueRegular,
            HelveticaNeueMedium,
        }
        public static Dictionary<FontTypes, string> FontTypeDictionary = new Dictionary<FontTypes, string>
        {
            {FontTypes.HelveticaNeueRegular, "HelveticaNeue"},
            {FontTypes.HelveticaNeueMedium, "HelveticaNeue-Medium"}
        };

        public static readonly BindableProperty FontColorProperty = BindableProperty.Create("FontColor", typeof(FontColors), typeof(CustomizableLabel), FontColors.Red);
        public FontColors FontColor
        {
            get { return (FontColors)GetValue(FontColorProperty); }
            set { SetValue(FontColorProperty, value); }

        }

        public enum FontColors
        {
            Red,
            Black,
        }
        public static Dictionary<FontColors, string> FontColorDictionary = new Dictionary<FontColors, string>
        {
            {FontColors.Red, "Color.Red"},
            {FontColors.Black, "Color.Black"}
        };
    }
}
