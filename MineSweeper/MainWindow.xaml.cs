using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Media.Animation;

namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer GemClock = new System.Windows.Threading.DispatcherTimer()
        {
            Interval = new TimeSpan(0, 0, 1)
        };

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

            Count_mine.Content = "0";

            GemClock.Tick += DispatcherTimer_Tick;
            GemClock.Stop();
            
            New_Game.Click += new RoutedEventHandler((s, ae) => { NewGame(); ReClock(); }); //  New_Game_Click; 
            ScoreTB.Click += new RoutedEventHandler((s, ae) => { CallScoreBoard(); });
        }
        private void StopTime()
        {
            GemClock.Stop();
            GemClock.IsEnabled = false;
        }
        private void ReClock()
        {  
            lblSeconds.Content = "00";
            lblMinutes.Content = "00";
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)// timer
        {
            int min = Convert.ToInt32(lblMinutes.Content);
            int sec = Convert.ToInt32(lblSeconds.Content);
            sec++;
            if (sec == 60)
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
        private void CallScoreBoard()
        {
            EndWindow form = new EndWindow();
            form.ShowDialog();
        }
        private void GameSummary(ref Desk[,] field, ref Settings game) //Summary current run and records data also calls EndWindow and InsNameWin
        {
            Random rnd = new Random();
            Score CurrentRun = new Score
            {
                Name = "Player #" + rnd.Next(9999),
                Result = 0,
                Difficulty = "Easy"
            };
            Sender sending = new Sender
            {
                sended = false
            };
            ScoreCounter(ref field, ref game, ref CurrentRun);
            ReClock();

            Thread insnm = new Thread(() =>
            {
                InsertNameWin popout = new InsertNameWin(CurrentRun, sending);
                popout.ShowDialog();
            });

            insnm.SetApartmentState(ApartmentState.STA);
            insnm.Start();
            insnm.Join();


            Thread insdb = new Thread(() =>
            {

                if (sending.sended)
                {
                    string querty = "INSERT INTO Scores ( Name, Result, Difficulty) " +
                                    "VALUES ( '" + CurrentRun.Name + "', '" + CurrentRun.Result + "', '" + CurrentRun.Difficulty + "' ) ";


                    SQLiteConnection con = new SQLiteConnection("Data Source=db/ScoreTable.db");
                    con.Open();

                    SQLiteCommand cmd = new SQLiteCommand(con);
                    cmd.CommandText = querty;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    CallScoreBoard();
                }
            });
            insdb.SetApartmentState(ApartmentState.STA);
            insdb.Start();
            insdb.Join();
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
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\mine_explode.jpg"));
                            field[i, j].button.Background = Brushes.Red;
                            field[i, j].button.Content = img1;
                        }
                        else
                        {
                            Image img1 = new Image();
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\mine_defused.jpg"));
                            field[i, j].button.Background = Brushes.Yellow;
                            field[i, j].button.Content = img1;
                        }
                    }
                }
            Field.IsEnabled = false;
            game.result = false;
            GameSummary(ref field, ref game);
        }
        private void Victory(ref Desk[,] field, ref Settings game) // end of game if playey set all flags
        {
            bool win = true; //check if all flags was set correctly
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
                            img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\mine_defused.jpg"));
                            field[i, j].button.Background = Brushes.Yellow;
                            field[i, j].button.Content = img1;
                            field[i, j].status = false; field[i, j].button.IsEnabled = false;
                        }
                    }
                }
            if (win)
            {
                Field.IsEnabled = false;
                game.result = true;
                GameSummary(ref field, ref game);
            }
            else GameOver(ref field, ref game);
        }
        private void ScoreCounter(ref Desk[,] field, ref Settings game, ref Score CurrentRun)// score counter for data in The end of game
        {
            int score = 0;
            int time = Convert.ToInt32(lblMinutes.Content) * 60 + Convert.ToInt32(lblSeconds.Content);
            double aps;
            if (time != 0)
                aps = (game.clicks + game.R_clicks) / time;
            else
                aps = (game.clicks + game.R_clicks) / 1;

            switch (game.width)
            {
                case 9: // Easy mode
                    {
                        CurrentRun.Difficulty = "Easy";
                        score = 9000 - 15 * (time);
                        if (score < 500) score = 500;
                        if (aps >= 1) score += 250;
                        if (!game.result) score /= 4;
                        break;
                    }
                case 16: // Medium mode
                    {
                        CurrentRun.Difficulty = "Medium";
                        score = 16000 - 15 * (time) - 25 * game.R_clicks;
                        if (score < 1000) score = 1000;
                        if (aps >= 1) score += 500;
                        if (!game.result) score /= 4;
                        break;
                    }
                case 30: // Hard mode
                    {
                        CurrentRun.Difficulty = "Hard";
                        score = 30000 - 15 * (time) - 50 * game.R_clicks;
                        if (score < 1500) score = 1500;
                        if (aps >= 1) score += 750;
                        if (!game.result) score /= 4;
                        break;
                    }
            }
            CurrentRun.Result = score;
        }
        private void Action(int i, int j, ref Desk[,] field, ref Settings game) // action which happend after common click
        {
            if (!field[i, j].flaged)
            {
                if (field[i, j].value == "*")
                {
                    StopTime();
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
                img1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\flag.jpg"));
                field[i, j].button.Content = img1;
                int count = Convert.ToInt32(Count_mine.Content);
                count--;
                if (count == 0)
                {
                    StopTime();
                    Victory(ref field, ref game);
                }
                Count_mine.Content = Convert.ToString(count);
            }
            else
            {
                game.R_clicks++;
                field[i, j].flaged = false;
                field[i, j].button.Content = ' ';
                int count = Convert.ToInt32(Count_mine.Content);
                count++;
                Count_mine.Content = Convert.ToString(count);
            }
        }
        private void Counter(ref Desk[,] field, int i, int j, ref Settings game) // counting number of mines around chosen button
        {
            field[i, j].status = false; field[i, j].button.IsEnabled = false;
            int count = 0;
            int startN = i - 1, endHeight = i + 2;
            int startM = j - 1, endWidth = j + 2;

            while (game.height < endHeight)
                endHeight--;

            while (-1 >= startN)
                startN++;

            while (game.width < endWidth)
                endWidth--;

            while (-1 >= startM)
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
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\1.jpg"));
                            break;
                        }
                    case 2:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\2.jpg"));
                            break;
                        }
                    case 3:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\3.jpg"));
                            break;
                        }
                    case 4:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\4.jpg"));
                            break;
                        }
                    case 5:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\5.jpg"));
                            break;
                        }
                    case 6:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\6.jpg"));
                            break;
                        }
                    case 7:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\7.jpg"));
                            break;
                        }
                    case 8:
                        {
                            img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\images\8.jpg"));
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
            field[i, j].button.Content = img;
        }
        public void NewGame()// new game starter
        {
            Field.IsEnabled = true;
            ScoreField.Visibility = Visibility.Visible;

            Settings game = new Settings
            {
                clicks = 0,
                R_clicks = 0
            };

            if (easyCB.Equals(Diff.SelectedItem))  // Easy mode
            {
                game.height = 9; game.width = 9; // 9 x 9 
                game.mines = 10;
                Count_mine.Content = "10";

                GameWin.Height = 500;
                GameWin.Width = 600;
                Field.Height = 225;
                Field.Width = 225;
                Field.Margin = new Thickness(25, 70, 50, 100);
            }

            if (meddiumCB.Equals(Diff.SelectedItem)) // Meddium mode
            {
                game.height = 16; game.width = 16; // 16 x 16 
                game.mines = 40;
                Count_mine.Content = "40";

                GameWin.Height = 600;
                GameWin.Width = 600;
                Field.Height = 400;
                Field.Width = 400;
                Field.Margin = new Thickness(0, 100, 0, 0);
            }

            if (hardCB.Equals(Diff.SelectedItem)) // Hard mode
            {
                game.height = 16; game.width = 30;  // 16 x 30 
                game.mines = 99;
                Count_mine.Content = "99";

                GameWin.Height = 600;
                GameWin.Width = 1000;
                Field.Height = 400;
                Field.Width = 750;
                Field.Margin = new Thickness(0, 100, 0, 0);
            }

            Desk[,] field = new Desk[game.height, game.width];

            for (int i = 0; i < game.height; i++) // creation of field
                for (int j = 0; j < game.width; j++)
                {
                    field[i, j] = new Desk
                    {
                        value = " ",
                        status = true,
                        flaged = false
                    };
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
                    b.Click += new RoutedEventHandler((s, ae) => 
                    { 
                        Action(a, bb, ref field, ref game); 
                        GemClock.Start(); 
                    });
                    b.MouseRightButtonDown += new MouseButtonEventHandler((s, ae) => Defuse(a, bb, ref field, ref game));
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Field.Children.Add(b);
                }
            }
        }
    }
}
