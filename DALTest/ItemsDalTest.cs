using System.ComponentModel;
using System;
using Xunit;
using DAL;
using Persistence;

namespace DALTest
{
    public class ItemsDALTest
    {
        private ItemsDal idal = new ItemsDal();
        private Items item = new Items();
        
        private const int GET_ALL = 0;
        private const int FILTER_BY_ITEM_NAME = 1;
        
        [Theory]
        [InlineData(3)]

        public void GetbyIDTest(int itemId)
        {
            Items result = idal.GetbyID(itemId);
            Assert.True(result != null);
            Assert.True(result.ItemId == itemId);
            
        }


        public void GetbyNameTest(string itemName)
        {
            Items item1 = new Items() { ItemName = itemName };
            
        }
    }
}