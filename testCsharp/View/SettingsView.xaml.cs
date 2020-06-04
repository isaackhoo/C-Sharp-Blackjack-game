using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testCsharp.Model;

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

            // bind data context
            //PlayerNameInputBox.DataContext = Settings.PlayerName;
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

        private void OnSaveAndExit(object sender, RoutedEventArgs e)
        {
            // update player name
            Settings.updatePlayerName(PlayerNameInputBox.Text);

            // update black jack target
            Settings.updateNumberOfDecks(NumberOfDecksInputBox.Text);

            //// update black jack target
            //Settings.updateBlackjackTarget(BlackjackTargetInputBox.Text);

            // return to title screen
            onBackToTitle(this, e);
        }

        //private void PlayerNameInputBoxPreview(object sender, TextCompositionEventArgs e)
        //{
        //    // no need for regex for player name
        //    // just accept whatever input
        //    e.Handled = true; // << not working. idk why
        //    PlayerNameInputBox.Text = e.Text; // force the textbox to update
        //}

        private void NumberOfDecksInputBoxPreview(object sender, TextCompositionEventArgs e)
        {
            // only allow numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //private void BlackjackTargetInputBoxPreview(object sender, TextCompositionEventArgs e)
        //{
        //    // only allow numbers
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
