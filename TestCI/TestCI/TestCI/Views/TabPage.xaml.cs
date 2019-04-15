using System.Collections.ObjectModel;
using TestCI.Database;
using Xamarin.Forms;
using TestCI.ViewModels;


namespace TestCI
{    
    public partial class TabPage 
    {      
        public TabPage()
		{
			InitializeComponent();
            BindingContext = new Testcodes();         
        }
    }
}
