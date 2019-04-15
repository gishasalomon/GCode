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
    public class Testcodes : INotifyPropertyChanged
    {

        DbManager database = new DbManager();

        private ObservableCollection<DataModel> pplList;
        
        private string fullname = "Monkey";
        
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
            DeleteItem = new Command(CDelete);
        }

        public ICommand DeleteItem { get; set; }
        void CDelete()
        {
            DataModel item= DbManager.DefaultInstance.GetItem(1);
            DbManager.DefaultInstance.DeleteItem(item);

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
                    fullname = people.Name + people.Designation;
            }

        }

        


    }
}
