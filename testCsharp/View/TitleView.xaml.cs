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
using testCsharp.Controller;
using testCsharp.Model;
using testCsharp.Model.Decks;

namespace testCsharp.View
{
    /// <summary>
    /// Interaction logic for TitleView.xaml
    /// </summary>
    public partial class TitleView : Page
    {
        public TitleView()
        {
            InitializeComponent();

            // hides the back and forward button provided by default
            ShowsNavigationUI = false;

            // disable buttons that are not in use
            HostGameButton.IsEnabled = false;
            JoinGameButton.IsEnabled = false;
        }

        private void onStartSinglePlayer(object sender, RoutedEventArgs e)
        {
            // initialize game variables
            // create a single player game state
            // this also clears out informaion of any previous game
            GameState.createGameState();

            // navigate user to game page
            // get navigation services
            NavigationService nav = NavigationService.GetNavigationService(this);
            // create game view page
            GameView gameView = new GameView();
            // navigate to game view page
            nav.Navigate(gameView);
        }

        private void GoToSettingsPage(object sender, RoutedEventArgs e)
        {
            // get navigation services
            NavigationService nav = NavigationService.GetNavigationService(this);
            // create game view page
            SettingsView settingsView = new SettingsView();
            // navigate to game view page
            nav.Navigate(settingsView);
        }
    }
}
