using System;
using System.Windows;
using System.IO;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Threading;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
//using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Printing;
using System.Windows.Documents;
using MineSweeper.db;

namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window
    {
        List<Score> scores;

        public EndWindow()
        {
            InitializeComponent();

            scores = new List<Score>(
                SqliteDataAccess<Score>.LoadData("SELECT * FROM Scores ORDER BY Result DESC"));

            ScoreTab.ItemsSource = scores;

            this.Closing += EndWindow_Closing;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDlg = new PrintDialog();
                if(printDlg.ShowDialog() == true)
                {
                    printDlg.PrintVisual(ScoreTab, "ScoreTab");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void EndWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            scores.Clear();
        }
    }
}
