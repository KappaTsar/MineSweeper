using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for InsertNameWin.xaml
    /// </summary>
    public partial class InsertNameWin : Window
    {
        public InsertNameWin(Score CurrentRes)
        {
            InitializeComponent();

            Random rnd = new Random();
            Player_name.Text = "Player #" + rnd.Next(9999);
            Send_button.Click += new RoutedEventHandler((s, ae) => InsName(CurrentRes));
        }

        private void InsName(Score CurrentRes)
        {
            CurrentRes.Player = Player_name.Text;
            Close();
        }
    }
}
