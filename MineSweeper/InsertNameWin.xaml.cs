using System;
using System.Windows;


namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for InsertNameWin.xaml
    /// </summary>
    public partial class InsertNameWin : Window
    {
        public InsertNameWin(Score CurrentRes, Sender sending)
        {
            InitializeComponent();

            Random rnd = new Random();
            Player_name.Text = "Player #" + rnd.Next(9999);
            CurrentRes.Name = Player_name.Text;

            Send_button.Click += new RoutedEventHandler((s, ae) => {
                CurrentRes.Name = Player_name.Text;
                sending.sended = true;
                Close();
            });
        }
    }
}
