using System;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Data.SQLite;
using System.Data;

namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for EndWindow.xaml
    /// </summary>
    public partial class EndWindow : Window
    {
        private System.ComponentModel.Container components;
        private Font printFont;
        private StreamReader streamToPrint;

        public EndWindow()
        {
            InitializeComponent();

            SQLiteConnection con = new SQLiteConnection("Data Source=db/ScoreTable.db");
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT * from Scores";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                con.Close();
                //Grid.DataContext = dt;
                /*while (reader.Read())
                {
                    
                    //Console.WriteLine(reader["Player"] + " : " + reader["Result"] + " : " + reader["Difficulty"]);
                }
                con.Close();*/
            }

        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                streamToPrint = new StreamReader
                   ("C:\\My Documents\\MyFile.txt");
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.Pd_PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            float linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                float yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

    }
}