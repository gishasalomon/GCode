using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Input;
using TestCI.Database;
using TestCI.Database.Models;
using Xamarin.Forms;

namespace TestCI.ViewModels
{
    public class Testcodes : INotifyPropertyChanged
    {

        DbManager database = new DbManager();

        private ObservableCollection<DataModel> pplList;
        
        private string fullname = "";
        
        public ObservableCollection<DataModel> PplList
        {
            get { return pplList = DbManager.DefaultInstance.GetDataModelItems(); }
            set {
                pplList.Clear(); 
            }
        }

        

        
        public string Fullname
        { get { return fullname; }
          set { }
        }

        
        

        private  string firstname = null;
        public  string Firstname
        {
            get { return firstname; }
            set { }
        }

        private  string designation = null;
        public  string Designation
        {
            get { return designation; }
            set { }
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

        public Testcodes()
        {
            ConcatenateCommand = new Command(CConcatenete);
           
        }

        public ICommand ConcatenateCommand { get; set; }
        void CConcatenete()
        {
            firstname = "Gisha";
            designation = "Engineer";
            Concatenate(firstname, designation, pplList);
            OnPropertyChanged("Fullname");
        }

        

        public  void Concatenate(string firstname, string designation, ObservableCollection<DataModel> pplList)
        {
            
            foreach (var people in pplList)
            {
                if (people.Name.Contains(firstname) && people.Designation.Contains(designation))
                    fullname = people.Name +" "+ people.Designation;
            }

           /* System.Net.WebClient client = new System.Net.WebClient();
            Uri uri = new Uri("http://192.168.70.122/TestCI.php");
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Name", "Test_name");
            parameters.Add("Designation", "Test_designation");
            parameters.Add("Country", "Test_country"); */

           // client.UploadValuesCompleted += client_UploadValuesCompleted();

        }
       




    }
}
