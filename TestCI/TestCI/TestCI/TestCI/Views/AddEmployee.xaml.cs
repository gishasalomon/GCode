using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCI.Database;
using TestCI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEmployee : ContentPage
	{
        AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();
       
		public AddEmployee ()
		{
			InitializeComponent ();
            BindingContext = addEmployeeViewModel;
        }
       /* public void Designation_SelectedIndexChanged()
        {
            //addEmployeeViewModel.SelectDesignation();
           
        }
        public void FirstName_TextChanged()
        {
            //addEmployeeViewModel.SelectDesignation();

        }
        public void LastName_TextChanged()
        {
            //addEmployeeViewModel.SelectDesignation();

        }*/


    }
}