namespace Persistence
{
    public class Items
    {
        public int ItemId { set; get; }
        public string ItemName { set; get; }
        public double ItemPrice { set; get; }
        public string ItemSize { set; get; }
        public string ItemDescription { set; get; }
        public override bool Equals(object obj)
        {
            if (obj is Items)
            {
                return ((Items)obj).ItemId.Equals(ItemId);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
        public class Categories
        {
            public int CategoryId { set; get; }
            public string CategoryName { set; get; }
        }

         public class ItemDetails
        {
            public Items ItemId { set; get; }
            public Categories CategoryId { set; get; }
            
        }
    }
}