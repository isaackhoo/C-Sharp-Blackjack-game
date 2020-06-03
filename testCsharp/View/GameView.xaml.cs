using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
using testCsharp.Model;
using testCsharp.Model.Decks;

namespace testCsharp.View
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        Player player;      

        public GameView()
        {
            InitializeComponent();

            // hides the back and forward button provided by default
            ShowsNavigationUI = false;

            // hide UI
            //HitButton.Visibility = Visibility.Hidden;
            //StayButton.Visibility = Visibility.Hidden;

            GameTextFeedback.Text = "illumina blackjack";
            GameTextFeedback.Visibility = Visibility.Hidden;

            // create a player object
            player = new Player("player 1");

            // add player to game state
            GameState.addPlayer(player);

            // bind hand from game state
            OverLayVisibleDealerHandList.ItemsSource = GameState.TableDealer.Hand.HandWithoutFirstCard;
            UnderLayCoveredDealerHandList.ItemsSource = GameState.TableDealer.Hand.HandWithoutFirstCard;
            RevealedPlayerHandList.ItemsSource = player.Hand.HandWithoutFirstCard;

            PlayerHandScoreTextBlock.DataContext = player;

            // test
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            // start the game
            GameState.startGame();
        }

        private void onExitButtonPress(object sender, RoutedEventArgs e)
        {
            // retrieve navigation service to move to another page
            NavigationService nav = NavigationService.GetNavigationService(this);
            // create page
            TitleView titleView = new TitleView();
            // navigate to game view page
            nav.Navigate(titleView);
        }

        private void OnHitButtonPress(object sender, RoutedEventArgs e)
        {
            GameState.hitForCurrentPlayer();
        }

        private void OnStayButtonPress(object sender, RoutedEventArgs e)
        {
            // GameState.endGame();
        }
    }
}
