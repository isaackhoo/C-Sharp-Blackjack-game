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
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void onBackToTitle(object sender, RoutedEventArgs e)
        {
            // get navigation services
            NavigationService nav = NavigationService.GetNavigationService(this);
            // create game view page
            TitleView titleView = new TitleView();
            // navigate to game view page
            nav.Navigate(titleView);
        }
    }
}
