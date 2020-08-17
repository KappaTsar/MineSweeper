using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MineSweeper
{
    public class Score : INotifyPropertyChanged
    {        
        private int result;
        private string difficulty;

        public string Player { get; set; }

        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }
        public string Difficulty
        {
            get { return difficulty; }
            set
            {
                difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}