using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using TicTacToe.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainMenu.NewGame += NewGame_Click;
            mainMenu.LoadGame += LoadGame_Click;
            mainMenu.Exit += Exit_Click;

            board.Back += Back_Click;
            board.OWins += Board_OWins;
            board.XWins += Board_XWins;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|All files (*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory
            };

            if (dialog.ShowDialog() == true)
            {
                board.Load(dialog.FileName);
                NewGame_Click(null, null);
            }
        }

        private void Board_XWins(object sender, System.EventArgs e)
        {
            MessageBox.Show("X won the match");
        }

        private void Board_OWins(object sender, System.EventArgs e)
        {
            MessageBox.Show("O won the match");
        }

        private void Back_Click(object sender, EventArgs e)
        {
            gBoard.Visibility = Visibility.Collapsed;
            gMainMenu.Visibility = Visibility.Visible;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            gMainMenu.Visibility = Visibility.Collapsed;
            gBoard.Visibility = Visibility.Visible;
        }
    }
}
