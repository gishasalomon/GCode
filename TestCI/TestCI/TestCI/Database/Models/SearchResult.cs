using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestCI.Database.Models
{
    public class SearchResult : INotifyPropertyChanged
    {
        public string rstring="lklk";
        public string Resultstring {
            get { return rstring; }
            set {
                this.rstring = value;
                OnPropertyChanged(nameof(rstring));
            } }

        public SearchResult()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    
}
