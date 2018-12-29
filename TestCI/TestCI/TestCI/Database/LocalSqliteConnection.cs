using System.Collections.Generic;

using TestCI.Database;
using SQLite;
using Xamarin.Forms;

namespace TestCI.Database
{
    
       
        public class LocalSqliteConnection
        {
            private static string _path = DependencyService.Get<IFileHelper>().GetLocalFilePath("people1.db");
            public static LocalSqliteConnection _defaultConnection;
            public SQLiteConnection SqLiteConnection = new SQLiteConnection(_path);

            public LocalSqliteConnection()
            {
            }

            public static LocalSqliteConnection DefaultConnection
            {
                get { return _defaultConnection ?? (_defaultConnection = new LocalSqliteConnection()); }
                private set { _defaultConnection = value; }

            }

            public void Connect(string newPath = null)
            {
                CloseConnection();

                if (newPath != null)
                {
                    _path = newPath;
                }

                SqLiteConnection = new SQLiteConnection(_path);

           
            }

            public void CloseConnection()
            {
                if (SqLiteConnection == null)
                    return;

                SqLiteConnection.Close();
                SqLiteConnection.Dispose();
                SqLiteConnection = null;
            }
        }
    }
