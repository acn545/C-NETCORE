using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {0,1,2,3,4,5,6,7,8,9};
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            Boolean[] values = new Boolean[10];
            // creates the values in the boolean array
            values[0] = true;
            for(int i = 1; i < values.Length;i++){
                if( values[i-1] == true){
                    values[i] = false;
                }else{
                    values[i] = true;
                }

            }
            // loops throught the array to display values
            for(int i = 0;i < values.Length;i++){
                Console.Write(values[i]);
            }
                int [,] multiTable  = new int[10,10];
                for(int i = 0; i < 10;i++){
                    for(int j = 0; j< 10;j++){
                        multiTable[i,j] = (i+1) * (j+1) ;
                    }
                }
                Console.WriteLine(" ");
                for( int x = 0; x < 10; x++){
                    for(int j = 0; j< 10;j++){
                        Console.Write(multiTable[x,j] + " ");
                    }
                    Console.WriteLine(" ");
                }

               //ice cream list
               List<string> iceCream = new List<string>();
               iceCream.Add("Blueberry");
               iceCream.Add("chocolate");
               iceCream.Add("Vanilla");
               iceCream.Add("Strawberry");
               iceCream.Add("Banana");
               Console.WriteLine("");
               Console.WriteLine(iceCream.Count);
               Console.WriteLine(iceCream[3]);
               iceCream.RemoveAt(3);
               Console.WriteLine(iceCream.Count);

               //dictionary
               Dictionary<string,string> name = new Dictionary<string,string>();
               Random rand = new Random();
               foreach(string key in names){
                   name.Add(key, iceCream[rand.Next(0,4)]);
               }
               foreach(KeyValuePair<string,string> key in name){
                    Console.WriteLine(key.Key + " " + key.Value );
               }

           
        }
    }
}
