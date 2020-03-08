using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MineSweeper
{
    public partial class MainWindow : Window
    {
        class Desk  
        {
            public string value;            
            public Button button;
            public bool status;
            public bool flaged;
        }

        public MainWindow()
        {
            InitializeComponent();
            lblSeconds.Content = "00";
            lblMinutes.Content = "00";
            Count_mine.Content = "0";

            System.Windows.Threading.DispatcherTimer Clock = new System.Windows.Threading.DispatcherTimer();
            Clock.Tick += DispatcherTimer_Tick;
            Clock.Interval = new TimeSpan(0, 0, 1);

            New_Game.Click += new RoutedEventHandler((s, ae) => NewGame(Clock)); //  New_Game_Click; 
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)// timer
        {
            int min = Convert.ToInt32(lblMinutes.Content);
            int sec = Convert.ToInt32(lblSeconds.Content);
            sec++;
            if(sec == 60)
            {
                sec = 0;
                min++;
            }
            if (sec < 10) lblSeconds.Content = '0' + Convert.ToString(sec);
            else lblSeconds.Content = Convert.ToString(sec);
            if (min < 10) lblMinutes.Content = '0' + Convert.ToString(min);
            else lblMinutes.Content = Convert.ToString(min);
            CommandManager.InvalidateRequerySuggested();
        }
        private int Score(ref Desk[,] field, ref Settings game)// score counter
        {
            int score = 0;
            int time = Convert.ToInt32(lblMinutes.Content) * 60 + Convert.ToInt32(lblSeconds.Content);
            double aps = 0;
            if (time != 0) 
                aps = (game.clicks + game.R_clicks) / time;
            else
                aps = (game.clicks + game.R_clicks) / 1;
            switch (game.width)
            {
                case 9: // Hard mode
                    {
                        score = 5000 - 30 * (time / 20);
                        if (!game.result)
                        {
                            score = (score - 5000) * (-1);
                            while (score > 500) score -= 500;
                        }
                        if (aps >= 1) score += 250;                        
                        break;
                    }
                case 16: // Medium
                    {
                        score = 7500 - 20 * (time / 20) - 25 * game.R_clicks;
                        if (!game.result)
                        {
                            score = (score - 7500) * (-1);
                            while (score > 500) score -= 500;
                        }
                        if (aps >= 1) score += 400;
                        break;
                    }
                case 30:
                    {
                        score = 10000 - 15 * (time / 20) - 50 * game.R_clicks;
                        if (!game.result)
                        {
                            score = (score - 10000) * (-1);
                            while (score > 500) score -= 500;
                        }
                        if (aps >= 1) score += 600;
                        break;
                    }
            }
            return score;
        }

        private void GameOver(ref Desk[,] field, ref Settings game) // end of game if player pick mine
        {            
            for (int i = 0; i < game.height; i++)
                for (int j = 0; j < game.width; j++)
                {
                    if (field[i, j].value == "*")
                    {
                        if (!field[i, j].flaged)
                        {
                            Image img1 = new Image();
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\mine_explode.jpg"));
                            field[i, j].button .Background = Brushes.Red;
                            field[i, j].button .Content = img1;
                        }
                        else
                        {
                            Image img1 = new Image();
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\mine_defused.jpg"));
                            field[i, j].button .Background = Brushes.Yellow;
                            field[i, j].button .Content = img1;                            
                        }
                    }
                }
            Field.IsEnabled = false;
            game.result = false;
            EndWindow form = new EndWindow(false, Score(ref field, ref game));                      
            form.Show();                     
        }       

        private void Victory(ref Desk[,] field, ref Settings game) // end of game if playey set all flags
        {
            bool win = true;
            for (int i = 0; i < game.height; i++)
                for (int j = 0; j < game.width; j++)
                {
                    if (field[i, j].flaged)
                    {
                        if (field[i, j].value != "*")
                            win = false;
                        else
                        {
                            Image img1 = new Image();
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\mine_defused.jpg"));
                            
                            field[i, j].button .Background = Brushes.Yellow;
                            field[i, j].button .Content = img1;
                            field[i, j].status = false; field[i, j].button .IsEnabled = false;
                        }
                    }
                }
            if (win)
            {
                game.result = true;
                EndWindow form = new EndWindow(true, Score(ref field, ref game));
                form.Show();
            }
            else GameOver(ref field, ref game);
        }

        private void Action(int i, int j, ref Desk[,] field, ref Settings game) // action which happend after common click
        {            
            if (!field[i, j].flaged)
            {
                if (field[i, j].value == "*")
                {
                    GameOver(ref field, ref game);
                }
                else
                {
                    game.clicks++;
                    Counter(ref field, i, j, ref game);
                }
            }
        }

        private void Defuse(int i, int j, ref Desk[,] field, ref Settings game) // setting on and setting off flags
        {
            if (!field[i, j].flaged)
            {
                field[i, j].flaged = true; 
                Image img1 = new Image();
                img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\flag.jpg"));
                field[i, j].button .Content = img1;
                int count = Convert.ToInt32(Count_mine.Content);
                count--;
                if (count == 0)
                    Victory(ref field, ref game);
                Count_mine.Content = Convert.ToString(count);
            }
            else
            {
                game.R_clicks++;
                field[i, j].flaged = false; 
                field[i, j].button .Content = ' ';
                int count = Convert.ToInt32(Count_mine.Content);
                count++;                
                Count_mine.Content = Convert.ToString(count);
            }                      
        }

        private void Counter(ref Desk[,] field, int i , int j, ref Settings game) // counting number of mines around chosen button
        {            
            field[i, j].status = false; field[i, j].button.IsEnabled = false;
            int count = 0;
            int startN = i - 1, endHeight = i + 2;
            int startM = j - 1, endWidth = j + 2;

            while (game.height < endHeight)
                endHeight--;
            
            while (-1 >= startN)
                startN++;
            
            while(game.width < endWidth)
                endWidth--;
            
            while(-1 >= startM)
                startM++;
            
            for (int ik = startN; ik < endHeight; ik++)
                for (int jk = startM; jk < endWidth; jk++)
                {                    
                    if (field[ik, jk].status)                    
                        if (field[ik, jk].value == "*")
                            count++;                                   
                }
            
            Image img = new Image();
            if (count != 0)
            {                
                switch (count)
                {
                    case 1:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\1.jpg"));
                            break;
                        }
                    case 2:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\2.jpg"));
                            break;
                        }
                    case 3:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\3.jpg"));
                            break;
                        }
                    case 4:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\4.jpg"));
                            break;
                        }
                    case 5:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\5.jpg"));
                            break;
                        }
                    case 6:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\6.jpg"));
                            break;
                        }
                    case 7:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\7.jpg"));
                            break;
                        }
                    case 8:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"..\..\images\8.jpg"));
                            break;
                        } 
                } 
            }
            else
            {
                for (int ik = startN; ik < endHeight; ik++)
                    for (int jk = startM; jk < endWidth; jk++)
                    {
                        if (field[ik, jk].status)
                            Counter(ref field, ik, jk, ref game);
                    }
            } 
            field[i, j].button .Content = img;
        }     

        public void NewGame(DispatcherTimer clock)// new game starter
        {
            Field.IsEnabled = true;
            ScoreField.Visibility = Visibility.Visible;
            clock.Stop();
            lblSeconds.Content = "00";
            lblMinutes.Content = "00";
            
            
            Settings game = new Settings();
            game.clicks = 0;
            game.R_clicks = 0;

            if (easyCB.Equals(Diff.SelectedItem))  // Easy
            {
                game.height = 9; game.width = 9; // 9 x 9 
                game.mines = 10;
                Count_mine.Content = "10";

                MineSweeper.Height = 500;
                MineSweeper.Width = 600;
                Field.Height = 225;
                Field.Width = 225;
                Field.Margin = new Thickness( 25, 70, 50, 100 );
            }

            if (meddiumCB.Equals(Diff.SelectedItem)) // Meddium 
            {
                game.height = 16; game.width = 16; // 16 x 16 
                game.mines = 40;
                Count_mine.Content = "40";

                MineSweeper.Height = 650;
                MineSweeper.Width = 600;
                Field.Height = 400;
                Field.Width = 400;
                Field.Margin = new Thickness( 0, 100, 0, 0 );          
            }

            if (hardCB.Equals(Diff.SelectedItem)) // Hard bugged
            {
                game.height = 16; game.width = 30;  // 16 x 30 
                game.mines = 99;
                Count_mine.Content = "99";                
                
                MineSweeper.Height = 650;
                MineSweeper.Width = 1200;
                Field.Height = 400;
                Field.Width = 750;
                Field.Margin = new Thickness(0, 100, 0, 0);
            }

            Desk[,] field = new Desk[game.height, game.width];

            for (int i = 0; i < game.height; i++) // creation of field
                for (int j = 0; j < game.width; j++)
                {
                    field[i, j] = new Desk();
                    field[i, j].value = " ";
                    field[i, j].status = true;
                    field[i, j].flaged = false;
                }

            bool f = false;
            Random rnd = new Random();
            for (int i = 0; i < game.mines; i++) // putting mines                
                do
                {
                    int Fi = rnd.Next(game.height);
                    int Fj = rnd.Next(game.width);
                    if (field[Fi, Fj].value != "*")
                    {
                        field[Fi, Fj].value = "*";
                        f = false;
                    }
                    else { f = true; }
                } while (f);

            for (int i = 0; i < game.height; i++) // viusalisation of field
            {                
                Field.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });

                for (int j = 0; j < game.width; j++)
                {
                    Field.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(25) });
                    Button b = new Button();
                    field[i, j].button = b;
                    int a = i;
                    int bb = j;
                    b.Click += new RoutedEventHandler((s, ae) => { Action(a, bb, ref field, ref game);  clock.Start(); });
                    b.MouseRightButtonDown += new MouseButtonEventHandler((s, ae) => Defuse(a, bb, ref field, ref game));
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Field.Children.Add(b);
                }
            }
        }
    }
}
