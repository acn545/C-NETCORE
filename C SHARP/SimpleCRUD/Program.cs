using System;
using DbConnection;
using System.Collections.Generic;

namespace SimpleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputLine = "something";
                while(InputLine != "exit"){
                List<Dictionary<string , object>> users = DbConnector.Query("SELECT * FROM users");
                foreach(var user in users){
                    Console.WriteLine(" users name: {0} {1}, Favorite number: {2}",user["FirstName"],  user["LastName"], user["FavoriteNumber"]);

                }
                Console.WriteLine("Enter a first Name to add a new user or exit to terminate application: ");
                InputLine = Console.ReadLine();
                if(InputLine == "exit"){

                    break;
                }
                Console.WriteLine("Enter a last Name: ");
                string InputLast = Console.ReadLine();
                Console.WriteLine("Enter a favorite number: ");
                string InputFav = Console.ReadLine();
                DbConnector.Execute($"INSERT INTO users (id, FirstName, LastName, FavoriteNumber) VALUES(6, '{InputLine}', '{InputLast}', {InputFav})");
            }
        }
    }
}
