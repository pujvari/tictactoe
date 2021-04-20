using System;
using System.Windows.Controls;

namespace TicTacToe.Controls
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public event EventHandler NewGame;
        public event EventHandler LoadGame;
        public event EventHandler Options;
        public event EventHandler Exit;

        private void newGame_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewGame(null, null);
        }

        private void loadGame_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LoadGame(null, null);
        }

        private void options_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Options(null, null);
        }

        private void exit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Exit(null, null);
        }
    }
}
