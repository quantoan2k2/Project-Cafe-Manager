using System.Collections.Generic;
using Persistence;
using DAL;
namespace BL
{
    public class ItemsBl
    {
        private ItemsDal idal = new ItemsDal();
        public Items SearchById(int itemId)
        {
            return idal.GetbyID(itemId);
        }
        public List<Items> GetAll()
        {
            return idal.GetItems(ItemFilter.GET_ALL, null);
        }
        public List<Items> SearchByName(string itemName)
        {
            return idal.GetItems(ItemFilter.FILTER_BY_ITEM_NAME, new Items { ItemName = itemName });
        }
        
    }
}