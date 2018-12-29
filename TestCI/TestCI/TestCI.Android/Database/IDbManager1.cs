using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestCI.Database
{
    public interface IDbManager1
    {
        void DeleteItem(DataModel item);
        ObservableCollection<DataModel> GetDataModelItems();
        DataModel GetItem(long? id, Guid guid = default(Guid));
        ObservableCollection<PromotionModel> GetPromotionModelItems();
        void InsertAll(IEnumerable<DataModel> items);
        void InsertDatamodel(DataModel item);
        void UpdateAll(IEnumerable<DataModel> items);
        void UpdateItem(DataModel item);
        void UpsertItem(DataModel item, Guid guid = default(Guid));
    }
}