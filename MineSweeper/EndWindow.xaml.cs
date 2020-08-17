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
using System.Data.Entity;
using SQLiteApp;

namespace MineSweeper
{

    public partial class EndWindow : Window
    {
        private ApplicationContext db;

        public EndWindow(bool win, int scoreRes)
        {   InitializeComponent();

            db = new ApplicationContext();
            db.Scores.Load();
            this.DataContext = db.Scores.Local.ToBindingList();

            InsertNameWin popOutWin = new InsertNameWin(new Score());

            if (popOutWin.ShowDialog() == true)
            {
                Score score = popOutWin.Score;
                db.Scores.Add(score);
                db.SaveChanges();
            }

            /* if (win)
            {
                Title.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\Win.jpg")));
            }
            else
            {
                Title.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\Lose.jpg")));
            }
            Score_box.Content = Convert.ToString(scoreRes);*/
            NextGame.Click += NextGame_Click;            
        }

        private void NextGame_Click(object sender, RoutedEventArgs e)
        {        
            Close();
        }    
    }
}
