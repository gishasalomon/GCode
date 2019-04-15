using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestCI.Database;

namespace TestCI.ViewModels
{
    class HomePageViewModel
    {
        public ObservableCollection<DataModel> AllData { get; set; } 

        public ObservableCollection<PromotionModel> PromotionModels { get; set; }

        
        public HomePageViewModel()
        {
            AllData = DbManager.DefaultInstance.GetDataModelItems();

            PromotionModels = DbManager.DefaultInstance.GetPromotionModelItems();
            
    }   }
}
