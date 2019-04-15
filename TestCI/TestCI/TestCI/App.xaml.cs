using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using TestCI.Database;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Specialized;
using System.Net;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TestCI
{
	public partial class App : Application
	{
        

        public App()
        {
            InitializeComponent();
            LocalSqliteConnection.DefaultConnection.CloseConnection();
            LocalSqliteConnection.DefaultConnection.Connect();
            DbManager.DefaultInstance.InsertDatamodel();
                    
            MainPage = new TabPage();
        }

        protected override void OnStart ()
		{
            DbManager.DefaultInstance.DeleteAll();
            AppCenter.Start("android=ea7f39d8-35db-4040-ae42-680e38c41b18;" ,
                  typeof(Analytics), typeof(Crashes));
                                 
        }   

        
		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
