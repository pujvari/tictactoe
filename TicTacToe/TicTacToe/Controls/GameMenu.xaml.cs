using System;
using System.Windows.Controls;

namespace TicTacToe.Controls
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameMenu : UserControl
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        public event EventHandler Back;
        public event EventHandler Reset;
        public event EventHandler Save;
        public event EventHandler OClick;
        public event EventHandler XClick;

        private void back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Back(null, null);
        }

        private void reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Reset(null, null);
        }

        private void save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Save(null, null);
        }

        private void basicO_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OClick(null, null);
        }

        private void basicX_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            XClick(null, null);
        }
    }
}
