using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL
{
    public static class ItemFilter
    {
        public const int GET_ALL = 0;
        public const int FILTER_BY_ITEM_NAME = 1;
        
    }
    public class ItemsDal
    {
        private string query;
        private MySqlConnection connection = DbHelper.GetConnection();
        public Items GetbyID(int itemId)
        {
            Items item = null;
            try
            {
                connection.Open();
                query = @"select item_id, item_name, item_price, item_size,
                            ifnull(item_description, '') as item_description 
                            from Items where item_id = @itemId;";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@itemId", itemId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    item = GetItem(reader);
                    //
                }
                reader.Close();
            }
            catch
            { }
            finally
            {
                connection.Close();
            }
            return item;
        }
        internal Items GetItem(MySqlDataReader reader)
        //
        {
            Items item = new Items();
            item.ItemId = reader.GetInt32("item_id");
            item.ItemName = reader.GetString("shoe_name");
            item.ItemPrice = reader.GetDouble("item_price");
            item.ItemSize = reader.GetString("item_size");
            item.ItemDescription = reader.GetString("item_description");
            return item;
        }

        public List<Items> GetItems(int itemFilter, Items item)
        {
            List<Items> lst = null;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("", connection);
                switch (itemFilter)
                {
                    case ItemFilter.GET_ALL:
                        query = @"select * from Items";
                        break;
                    case ItemFilter.FILTER_BY_ITEM_NAME:
                        query = @"select * from Items where item_name like concat('%',@itemName,'%');";
                        command.Parameters.AddWithValue("@itemName", item.ItemName);
                        break;
                   
                }
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                lst = new List<Items>();
                Console.WriteLine("┌────┬──────────────────────┬────────────┬────────────┬───────────────┐");
                Console.WriteLine("| ID | Name                 |  Price     |  Size      | Description   |");
                Console.WriteLine("├────┼──────────────────────┼────────────┼────────────┼───────────────┤");
                while (reader.Read())
                {
                    lst.Add(GetItem(reader));
                }
                reader.Close();
            }
            catch { }
            finally
            {
                connection.Close();
            }
            return lst;
        }
    }
}