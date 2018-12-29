using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TestCI.Database;
using UnitTestProject1.Resources;
using Moq;
using SQLite;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

using System.Data;
using UnitTestProject1.Extensions;
using System.Linq;
//using Xamarin.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest_AllWords
    {
        private IEnumerable<DataModel> dataModels { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var stream = TestCIData.PeopleData.ToStream();//getting the data from the XML document attached as the resource file 
            var reader = new StreamReader(stream);
            var serializer = new XmlSerializer(typeof(Collection<DataModel>));
            dataModels = (Collection<DataModel>)serializer.Deserialize(reader);//XML data deserialized as collection of <datamodel>
        }

        [TestMethod]
               
        public void Concatenate_validstring_expectedstring()
        {
            //Arrange
            // the datamodels collection is now converted as type observable collection which we set to be returned when the mock function "getdatamodelitems" is called. 

            ObservableCollection<DataModel> pplDbSet = new ObservableCollection<DataModel>();

            foreach (var dataModel in dataModels)
            {
                pplDbSet.Add(dataModel);
            }
            Mock<IDbManager1> dbmanager = new Mock<IDbManager1>();
            dbmanager.Setup(context => context.GetDataModelItems()).Returns(pplDbSet);
            Mock<IDataModel> item = new Mock<IDataModel>();

            var dbContext = dbmanager.Object;
            var data = dbContext.GetDataModelItems();

            TestCI.ViewModels.Testcodes testcodes = new TestCI.ViewModels.Testcodes();

            // the fucntion written in Source code dbmanager class "GetItems" is mocked using the Moq framework.
            // dbmanager.Setup(context => context.GetItems()).Returns(pplDbSet);
            // dbmanager.Setup(context => context.GetItem("gisha")).Returns(item );


            //Act

            testcodes.Concatenate("Gisha", "Engineer", data);
            
            //Assert
            Assert.AreEqual("GishaSoftware Engineer", testcodes.Fullname);
        }

        
    }
}
