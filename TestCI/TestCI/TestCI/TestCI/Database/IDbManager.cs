using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestCI.Database
{
    public interface IDbManager
    {
        
        void InsertAll(IEnumerable<DataModel> items);
        ObservableCollection<DataModel> GetDataModelItems();
       
    }
}
