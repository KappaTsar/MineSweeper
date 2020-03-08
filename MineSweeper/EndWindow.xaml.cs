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

    public partial class EndWindow : Window
    {       
        public EndWindow(bool win, int score)
        {   InitializeComponent();
               
            if (win)
            {
                Title.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\Win.jpg")));
            }
            else
            {
                Title.Background = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\Lose.jpg")));
            }
            Score_box.Content = Convert.ToString(score);
            NextGame.Click += NextGame_Click;            
        }

        private void NextGame_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }    
    }
}
