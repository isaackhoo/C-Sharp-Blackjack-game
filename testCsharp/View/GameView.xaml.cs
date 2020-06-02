using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testCsharp.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        public GameView()
        {
            InitializeComponent();

            // hides the back and forward button provided by default
            ShowsNavigationUI = false;
        }

        private void GoToTitleView(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Entered game view button click - go to title view");
            // retrieve navigation service to move to another page
            NavigationService nav = NavigationService.GetNavigationService(this);
            // create page
            TitleView titleView = new TitleView();
            // navigate to game view page
            nav.Navigate(titleView);
        }
    }
}
