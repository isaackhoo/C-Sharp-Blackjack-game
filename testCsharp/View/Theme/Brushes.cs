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

        // card colors
        public static SolidColorBrush CardWhite = new SolidColorBrush(Color.FromArgb(255, 216, 216, 216));
        public static SolidColorBrush CardBorder = new SolidColorBrush(Color.FromArgb(255, 184, 177, 177));
        public static SolidColorBrush CardRedSuits = new SolidColorBrush(Color.FromArgb(255, 181, 28, 22));
        public static SolidColorBrush CardBlackSuits = new SolidColorBrush(Color.FromArgb(255, 21, 22, 21));

        // text colors
        public static SolidColorBrush TextBlack = new SolidColorBrush(Colors.Black);
        public static SolidColorBrush TextWhite = new SolidColorBrush(Colors.White);
        public static SolidColorBrush TextDisabled = new SolidColorBrush(Color.FromArgb(255, 155, 155, 155));
    }
}
