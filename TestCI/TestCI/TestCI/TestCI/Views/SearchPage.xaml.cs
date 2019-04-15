using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCI.Database;
using TestCI.Database.Models;
using TestCI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
      /*  SearchViewModel searchViewModel = new SearchViewModel();
        private ObservableCollection<DataModel> searchsourcelist;
        public ObservableCollection<DataModel> SearchSourceList
        {
            get { return searchsourcelist; }
            set { }
        }
        private string searchresult;
        public ObservableCollection<SearchResult> sresultList;
        public ObservableCollection<SearchResult> SResultList
        {
            get { return sresultList; }
            set { sresultList= new ObservableCollection<SearchResult>{ }; }
        } */
        public SearchPage ()
		{
			InitializeComponent ();
            SearchViewModel searchViewModel = new SearchViewModel();
            BindingContext = searchViewModel;
            
        }
       /* public void SearchText_OnChange(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                return;
            string keyword = e.NewTextValue.Trim();

            
            Testcodes tc = new Testcodes();
            searchsourcelist = tc.PplList;
            sresultList = new ObservableCollection<SearchResult>() { new SearchResult { rstring = "View your results here" } };

            searchViewModel.Search(keyword, searchsourcelist);
             
        }*/
    }
}