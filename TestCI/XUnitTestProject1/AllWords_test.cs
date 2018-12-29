using System;
using System.Collections.Generic;
using TestCI;
using TestCI.Database;
using Xunit;

namespace XUnitTestProject1
{
    public class AllWords_test
    {
        [Fact]
        public void Countofwordsfetched()
        {
            //Arrange
            List<DataModel> pplList = DbManager.DefaultInstance.GetItems();

            //Assert
            Assert.Equal(7, pplList.Count);
        }
    }
}
