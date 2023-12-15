using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TodoREST.Models;

namespace TodoREST.ViewModel
{
    public class ShowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Show> Shows{ get; set; }

        void INotifyPropertyChanged(string name) 
        { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
