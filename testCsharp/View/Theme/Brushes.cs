using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace testCsharp.View.Theme
{
    public static class Brushes
    {
        public static SolidColorBrush Primary = new SolidColorBrush(Color.FromArgb(255, 255, 180, 65));
        public static SolidColorBrush Secondary = new SolidColorBrush(Color.FromArgb(255, 97, 97, 97));

        // text colors
        public static SolidColorBrush TextBlack = new SolidColorBrush(Colors.Black);
        public static SolidColorBrush TextWhite = new SolidColorBrush(Colors.White);
        public static SolidColorBrush TextDisabled = new SolidColorBrush(Color.FromArgb(255, 155, 155, 155));
    }
}
