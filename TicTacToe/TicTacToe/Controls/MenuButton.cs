using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe.Controls
{
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public class MenuButton : Button
    {
        public MenuButton()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;

            Background = Brushes.Black;
            Foreground = Brushes.Aqua;
        }
    }
}
