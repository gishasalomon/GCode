using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TestCI.Database;
using TestCI.Database.Models;
using Xamarin.Forms;

namespace TestCI.ViewModels
{
    class SearchViewModel : INotifyPropertyChanged
    {
        
       
        private ObservableCollection<DataModel> searchsourcelist;
        public ObservableCollection<DataModel> SearchSourceList
        {
            get { return searchsourcelist; }
            set {  }
        }
       
        public ObservableCollection<SearchResult> sresultList;
        public ObservableCollection<SearchResult> SResultList
        {
            get { return sresultList; }
            set { }
        }
        private string keyword=null;
        public string Keyword
        {
            get { return keyword; }
            set {
                if (keyword != value) { keyword = value; }
                OnPropertyChanged("Keyword");
            }
        }
        public SearchViewModel()
        {
            SearchCommand = new Command(Search);
            Testcodes tc = new Testcodes();
            searchsourcelist = tc.PplList;
            sresultList = new ObservableCollection<SearchResult>() { new SearchResult { Resultstring = "" } };
           
        }
        public ICommand SearchCommand { get; set; }
        void Search()
        {
            sresultList.Clear();
            Search(keyword, searchsourcelist);
            OnPropertyChanged("Resultstring");
            OnPropertyChanged("SResultList");
        }
        public void Search(string keyword, ObservableCollection<DataModel> searchsourcelist)
        {
            SearchResult result = new SearchResult();
            sresultList.Add(result);

            foreach (var people in searchsourcelist)
            {
                string name = people.Name.ToLower();
                string desgn = people.Designation.ToLower();
                keyword=keyword.ToLower();
                if (name.Contains(keyword)||desgn.Contains(keyword))
                {
                    result.Resultstring = people.Name +" "+ people.Designation;
                    sresultList.Add(result);
                   
                }
                
            }

            if (sresultList.Count == 1)
            {
               //sresultList.Clear();
                result.Resultstring = "No results for " + keyword;
                sresultList.Add(result);
            }

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
