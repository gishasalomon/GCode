using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TestCI.Database;
using TestCI.Database.Models;
using Xamarin.Forms;

namespace TestCI.ViewModels
{
    class AddEmployeeViewModel : INotifyPropertyChanged
    {
                
        public AddEmployeeViewModel()
        {
            List<String> DesignationList;
            DesignationList =new List<string>{ "Software Engineer","Senior Software Engineer", "Devops Engineer", "Product Manager", "CEO", "CTO" , "Team Lead"};
            SaveCommand = new Command(CSave);
        }
        private string firstname = "";
        public string FirstName
        {
            get { return firstname; }
            
            set {
                if (firstname != value) { firstname = value; }
                OnPropertyChanged("Firstname");
            }
        }

        private string lastname = "";
        public string LastName
        {
            get { return lastname; }
            set
            {
                if (lastname != value) { lastname = value; }
                OnPropertyChanged("LastName");
            }
        }

        private string designation = "";
        public string SelectedDesignation
        {
            get { return designation; }
            set
            {
                if (designation != value) { designation = value; }
                OnPropertyChanged("SelectedDesignation");
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

        public ICommand SaveCommand { get; set; }
        void CSave()
        {
           // firstname = Firstname;
           // designation = SelectedDesignation;
           // lastname = Lastname;
            DataModel item = new DataModel();
            item.Designation = designation;
            item.Name = FirstName + lastname;
            Database.DbManager.DefaultInstance.InsertDatamodel(item);
            
        }
 
    }
}
