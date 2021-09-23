using System;
using System.Collections.Generic;
using Persistence;
using BL;

namespace ConsoleAppPL
{
    class Program
    {

        static void Main(string[] args)
        {
            ItemsBl ibl = new ItemsBl();
            List<Items> lst = new List<Items>();

            while (true)
            {
                string pass;
                string userName;
                do
                {
                    Console.WriteLine("+──────────────────────────────────────────────────────────────────────────────────+");
                    Console.WriteLine("|                               ...LOGIN TO SYSTEM...                              |");
                    Console.WriteLine("|                                    CAFE  STORE                                   |");
                    Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                    Console.Write("| User Name: ");
                    userName = Console.ReadLine();
                    Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                    Console.Write("| Password: ");
                    pass = GetPassword();
                    Console.WriteLine("\n────────────────────────────────────────────────────────────────────────────────────");
                    if (pass.Length < 8)
                    {
                        Console.WriteLine("Password must be 8 characters or more");
                    }
                }while (pass.Length < 8);

                    Staff staff = new Staff() { UserName = userName, Password = pass };
                    StaffBl bl = new StaffBl();

                    staff = bl.Login(staff);
                    if (staff.Role <= 0)
                    {
                        Console.WriteLine("Can't Login");
                    }
                    else
                    {
                        break;
                    }
            }
            while (true)
            {
                Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("|                         Cafes Store System - Menu                                |");
                Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                Console.WriteLine("| 1.Search                                                                         |");
                Console.WriteLine("| 2.Invoices                                                                       |");
                Console.WriteLine("| 3.Exit System                                                                    |");
                Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
                Console.Write(" * Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("+──────────────────────────────────────────────────────────────────────────────────+");
                switch (choice)
                {
                    case 1:
                        int choi;
                        do
                        {
                            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
                            Console.WriteLine("|                     Cafes Store System - Search                                  |");
                            Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                            Console.WriteLine("| 1.Search name                                                                    |");
                            Console.WriteLine("| 2.Search id                                                                      |");
                            Console.WriteLine("| 4.Show all shoes                                                                 |");
                            Console.WriteLine("| 5.Exits Search                                                                   |");
                            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────┘");
                            Console.Write(" * Input choice: ");
                            choi = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("+──────────────────────────────────────────────────────────────────────────────────+");

                            switch (choi)
                            {
                                case 1: 
                                    string itemName;
                                    Console.Write("Input Search Name: ");
                                    itemName = Convert.ToString(Console.ReadLine());
                                    Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                    lst = ibl.SearchByName(itemName);
                                    if (lst == null)
                                    {
                                        Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                        Console.WriteLine("No results found for Name: " + itemName);

                                    }
                                    else
                                    {
                                        Console.WriteLine("\nNumber of results found By Name: " + lst.Count);
                                        Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                    }
                                    Console.WriteLine("\n    Press Enter key to back Search Menu...");
                                    Console.ReadKey();
                                    break;
                                case 2: 
                                    int itemId;
                                    Console.Write("*Input Search Id:");
                                    if (Int32.TryParse(Console.ReadLine(), out itemId))
                                    {
                                        Items i = ibl.SearchById(itemId);
                                        if (i != null)
                                        {
                                            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine("| Item ID: " + i.ItemId);
                                            Console.WriteLine("| Item Name:  " + i.ItemName);
                                            Console.WriteLine("| Item Price: " + i.ItemPrice + "$");
                                            Console.WriteLine("| Size:      " + i.ItemSize);
                                            Console.WriteLine("| Description " + i.ItemDescription);
                                            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────");
                                            Console.WriteLine(" !!! No results found for id " + itemId);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your Choose is wrong!");
                                    }
                                    Console.WriteLine("\n    Press Enter key to back Search Menu...");
                                    Console.ReadLine();
                                    break;
                                
                                case 3:
                                    lst = ibl.GetAll();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    break;

                            }
                        } while (choi != 4);
                        break;
                    case 2:
                        int c;
                        do
                        {
                            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
                            Console.WriteLine("|                     Cafes Store System - Invoices                                |");
                            Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                            Console.WriteLine("| 1. Create new invoice                                                            |");
                            Console.WriteLine("| 2. Invoices History                                                              |");
                            Console.WriteLine("| 3. Exits Invoices                                                                |");
                            Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                            Console.Write("* Your Choice: ");
                            c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
                                    Console.WriteLine("|                     Cafes Store System - Invoices                                |");
                                    Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                                    Console.Write("| Customer Name: ");
                                    break;
                                case 2:
                                    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────┐");
                                    Console.WriteLine("|                     Cafes Store System - Invoices                                |");
                                    Console.WriteLine("|──────────────────────────────────────────────────────────────────────────────────|");
                                    Console.Write("| Customer Phone Number: ");
                                    break;
                                case 3:
                                    break;

                                default:
                                    break;
                            }
                        } while (c != 3);
                        break;
                    case 3:

                        Console.WriteLine("DO YOU WANT TO EXIT SYSTEM...(Y/N)???");
                        string o = Console.ReadLine();
                        if (o == "Y" || o == "y")
                        {
                            Console.Write("GOOD BYE...");
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("PLEASE CHOOSE OPTION 1-3: ");
                        Console.Write("PRESS ENTER TO RE-CHOICE....");
                        Console.ReadKey();
                        break;
                }
            }

        }

        static string GetPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
    }
}
