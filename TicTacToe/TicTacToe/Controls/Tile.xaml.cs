using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TicTacToe.Controls
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public BitmapImage X;
        public BitmapImage O;

        public Tile()
        {
            InitializeComponent();

            X = new BitmapImage(new Uri(@"/Images/x.png", UriKind.Relative));
            O = new BitmapImage(new Uri(@"/Images/o.png", UriKind.Relative));
        }

        public bool IsXSelected { get; set; }

        public void Clear()
        {
            Picture.Source = null;
        }

        private void Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Picture.Source == null)
                Picture.Source = IsXSelected ? X : O;
        }

        public void Set(int value)
        {
            if (value == 1)
                Picture.Source = X;
            else if (value == 2)
                Picture.Source = O;
        }
    }
}
