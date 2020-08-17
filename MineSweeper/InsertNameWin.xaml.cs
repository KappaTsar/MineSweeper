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
        public Score Score { get; private set; }
        public InsertNameWin(Score scr)
        {
            InitializeComponent();
            Random rnd = new Random();
            Player_name.Text = "Player #" + rnd.Next(9999);

            Score = scr;
            this.DataContext = Score;
            Send_button.Click += InsertName_Click;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Player_name.SelectAll();
            Player_name.Focus();
        }

        private void InsertName_Click(object sender, RoutedEventArgs e)
        {
            //Send name in db
            this.DialogResult = true;
            //Close();
        }
    }
}
