using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCI.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        public void OnButtonClicked(object sender, EventArgs args)
        {
            //DbManager database = new DbManager();
           // ObservableCollection<DataModel> pplList = DbManager.DefaultInstance.GetDataModelItems();

            //ObservableCollection<DataModel> pplCollection = new ObservableCollection<DataModel>(pplList);
            //peopleList.ItemsSource = pplCollection;
        }
        
	}
}