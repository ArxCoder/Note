using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1_Work_12_Kuznetsov_IS_21_3.NewFolder1
{
    public class Note : INotifyPropertyChanged
    {
        public DateTime Creation { get; set; } = DateTime.Now;

        private bool Is_Done;
        private string This_Text;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsDone
        {
            get { return Is_Done; }
            set 
            {  
                if (IsDone == value) return;
                Is_Done = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Text
        {
            get { return This_Text; }
            set 
            {
                if (This_Text == value) return;
                This_Text = value;
                OnPropertyChanged("Text");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
