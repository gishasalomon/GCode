using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestCI.Database
{
        [Table("promotion")]
        public class PromotionModel
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
            private string _promotionName;
            [NotNull]
            public string PromotionName
            {
                get
                {
                    return _promotionName;
                }
                set
                {
                    this._promotionName = value;
                    OnPropertyChanged(nameof(PromotionName));
                }
            }
            private string _imageUrl;
            [MaxLength(50)]
            public string ImageUrl
            {
                get
                {
                    return _imageUrl;
                }
                set
                {
                    this._imageUrl = value;
                    OnPropertyChanged(nameof(ImageUrl));
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

