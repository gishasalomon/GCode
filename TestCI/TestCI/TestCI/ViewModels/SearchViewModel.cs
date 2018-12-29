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
        private string searchresult;
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
            sresultList = new ObservableCollection<SearchResult>() { new SearchResult { rstring = "View your results here" } };

        }
        public ICommand SearchCommand { get; set; }
        void Search()
        {
            Search(keyword, searchsourcelist);
            OnPropertyChanged("Resultstring");
            OnPropertyChanged("SResultList");
        }
        public void Search(string keyword1, ObservableCollection<DataModel> searchsourcelist)
        {
            SearchResult result = new SearchResult();
            result.rstring = "Obtained results for " + keyword1;
            //sresultList.Clear();
            sresultList.Add(result);

            foreach (var people in searchsourcelist)
            {
                               
                if (people.Name.Contains(keyword1)||people.Designation.Contains(keyword1)||people.Designation.Contains(keyword1))
                {
                    searchresult = people.Name +" "+ people.Designation;
                    result.rstring = searchresult;
                    if (sresultList.Count > 0)
                    {
                        foreach (SearchResult item in sresultList)
                        {
                            if (item.rstring.Equals(result.rstring)) { return; }
                            else
                            {
                                sresultList.Add(result);
                                return;
                            }
                        }
                    }
                   
                }
                
            }

            if (sresultList.Count == 1)
            {
               // sresultList.Clear();
                result.rstring = "No results for " + keyword1;
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
