using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe.Controls
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();

            Tiles = new List<Tile>
            {
                tile00,
                tile01,
                tile02,
                tile10,
                tile11,
                tile12,
                tile20,
                tile21,
                tile22
            };

            gameMenu.XClick += BasicX_Click;
            gameMenu.OClick += BasicO_Click;
            gameMenu.Save += Save_Click;
            gameMenu.Reset += Reset_Click;
            gameMenu.Back += Back_Click;

            foreach (var item in Tiles)
                item.Click += Button_Click;

            BasicX_Click(null, null);
        }

        public List<Tile> Tiles { get; set; }

        public event EventHandler XWins;
        public event EventHandler OWins;

        public event EventHandler Back;

        public void Load(string filename)
        {
            var content = File.ReadAllText(filename);
            var array = JsonSerializer.Deserialize<int[]>(content);

            for (int i = 0; i < Tiles.Count; i++)
                Tiles[i].Set(array[i]);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var res = GetGameResult();
            switch (res)
            {
                case 1:
                    XWins(null, null);
                    break;
                case 2:
                    OWins(null, null);
                    break;
                default:
                    break;
            }

            if (Tiles.First().IsXSelected)
                BasicO_Click(null, null);
            else
                BasicX_Click(null, null);

        }

        private int GetGameResult()
        {
            var a = Tiles.Select(x => x.Picture.Source == x.X ? 1 : x.Picture.Source == x.O ? 2 : 0).ToArray();

            for (int i = 0; i < a.Length; i += 3)
                if (a[i] * a[i + 1] * a[i + 2] == 1)
                    return 1;
                else if (a[i] * a[i + 1] * a[i + 2] == 8)
                    return 2;

            for (int i = 0; i < 3; i++)
                if (a[i] * a[i + 3] * a[i + 6] == 1)
                    return 1;
                else if (a[i] * a[i + 3] * a[i + 6] == 8)
                    return 2;

            if (a[0] * a[4] * a[8] == 1)
                return 1;

            if (a[0] * a[4] * a[8] == 8)
                return 2;

            if (a[2] * a[4] * a[6] == 1)
                return 1;

            if (a[2] * a[4] * a[6] == 8)
                return 2;

            return 0;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Tiles.ForEach(x => x.Clear());
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var a = Tiles.Select(x => x.Picture.Source == x.X ? 1 : x.Picture.Source == x.O ? 2 : 0).ToArray();
            File.WriteAllText($"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.json", JsonSerializer.Serialize(a));
        }

        private void BasicX_Click(object sender, EventArgs e)
        {
            Tiles.ForEach(x => x.IsXSelected = true);
            gameMenu.basicX.Background = Brushes.Yellow;
            gameMenu.basicO.Background = Brushes.Transparent;
        }

        private void BasicO_Click(object sender, EventArgs e)
        {
            Tiles.ForEach(x => x.IsXSelected = false);
            gameMenu.basicX.Background = Brushes.Transparent;
            gameMenu.basicO.Background = Brushes.Yellow;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Back(null, null);
        }
    }
}
