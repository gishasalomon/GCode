using SQLite;
using System.ComponentModel;
using TestCI.Database;

namespace TestCI.Database
{
    [Table("people")]
    public class DataModel : IDataModel
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _Name;
        [NotNull]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this._Name = value;
                OnPropertyChanged(nameof(_Name));
            }
        }
        private string _designation;
        [MaxLength(50)]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                this._designation = value;
                OnPropertyChanged(nameof(Designation));
            }
        }
        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }

}

