using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

using SQLite;

namespace TestCI.Database
{
    public class DbManager : IDbManager
    {
        private static DbManager _defaultInstance;
        public readonly SQLiteConnection _dbConnection = LocalSqliteConnection.DefaultConnection.SqLiteConnection;

        public DbManager()
        {
           _dbConnection.CreateTable<DataModel>();
           // _dbConnection.CreateTable<PromotionModel>();

        }

        public static DbManager DefaultInstance
        {
            get { return _defaultInstance ?? (_defaultInstance = new DbManager()); }
            private set { _defaultInstance = value; }
        }

        public void InsertDatamodel()
        {
           
            DataModel item1 = new DataModel();  
            item1.Name = "Gisha";
            item1.Country = "India";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

            item1.Name = "Reeha";
            item1.Country = "India";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

            item1.Name = "Sophiya";
            item1.Country = "India";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

            item1.Name = "Renish";
            item1.Country = "India";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

            item1.Name = "Marco";
            item1.Country = "Brazil";
            item1.Designation = "Product Manager";
            _dbConnection.Insert(item1);

            item1.Name = "Ritin";
            item1.Country = "India";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

            item1.Name = "Subhan";
            item1.Country = "Pakistan";
            item1.Designation = "Software Engineer";
            _dbConnection.Insert(item1);

        }
       /* public void InsertPromotionmodel(PromotionModel item)
        {
            try
            {
                item.ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png";
                item.PromotionName = "Woodland Park Zoo";
                _dbConnection.Insert(item);

                item.ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png";
                item.PromotionName = "Cleveland Zoo";
                _dbConnection.Insert(item);
            }
            catch(Exception e)
            { Console.WriteLine(e); }
        }*/

            public void InsertAll(IEnumerable<DataModel> items)
        {
            _dbConnection.InsertAll(items);
        }

        public void UpdateItem(DataModel item)
        {
            _dbConnection.Update(item);
        }

        public void UpdateAll(IEnumerable<DataModel> items)
        {
            _dbConnection.UpdateAll(items);
        }

        public void UpsertItem(DataModel item, Guid guid = default(Guid))
        {
            DataModel itemFromDb = GetItem(item.Id, guid);
            if (itemFromDb != null)
                UpdateItem(item);
            else
                InsertDatamodel();
        }

        public void DeleteAll()
        {
            _dbConnection.DropTable<DataModel>();
        }

        public DataModel GetItem(long? id, Guid guid = default(Guid))
        {
            try
            {
                if (id != null && id != 0)
                {
                    DataModel item = _dbConnection.Get<DataModel>(id);
                    return item;
                }
                else if (guid != default(Guid))
                {
                    DataModel item = _dbConnection.Get<DataModel>(guid);
                    return item;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Db error: {0}", e.Message);
            }
            return null;
        }

        public ObservableCollection<DataModel> GetDataModelItems()
        {
            try
            {
                List<DataModel> items = new List<DataModel>();

                TableQuery<DataModel> tableQuery = _dbConnection.Table<DataModel>();

                items = tableQuery.ToList();

                ObservableCollection<DataModel> odatas = new ObservableCollection<DataModel>(items as List<DataModel>);

                return odatas;
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Db error: {0}", e.Message);
            }
            return null;
        }
        public ObservableCollection<PromotionModel> GetPromotionModelItems()
        {
            try
            {
                List<PromotionModel> items = new List<PromotionModel>();

                TableQuery<PromotionModel> tableQuery = _dbConnection.Table<PromotionModel>();

                items = tableQuery.ToList();

                ObservableCollection<PromotionModel> odatas = new ObservableCollection<PromotionModel>(items as List<PromotionModel>);

                return odatas;
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Db error: {0}", e.Message);
            }
            return null;
        }
    }
}