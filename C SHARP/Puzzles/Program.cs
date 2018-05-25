using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = new int[10];
            string[] names = new string[] {"todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            RandomArray(num1);
            TossCoin();
            Names(names);
        }
        //Random Array 
        public static void RandomArray(int[] arr){
            Random rand = new Random();
            int sum = 0;
            for( int i = 0; i < 10;i++){
                arr[i] = rand.Next(5,25);
                sum += arr[i];
                Console.Write(arr[i] + " ");
                
            }
            Console.WriteLine(" ");
            Console.WriteLine("the sum of the array is {0}", sum);
            int max = arr[0];
            int min = arr[0];
            for( int i = 0; i < 10;i++){
                if(max < arr[i]){
                    max = arr[i];
                }
                if(min > arr[i] ){
                    min = arr[i];
                }
            }
            Console.WriteLine("the max number is {0}", max);
            Console.WriteLine("the min number is {0}", min);
        }
        // Coin Flip
        public static void TossCoin(){
            Console.WriteLine("Tossing a Coin...");
            Random rand = new Random();
            int flip = rand.Next(0,2);
            if(flip == 1){
                Console.WriteLine("It was Heads!");
            }else{
                Console.WriteLine("It was Tails!");
            }
        }

        //names
        public static void Names(string[] arr){
            Random rand = new Random();
            for(int i = 0; i < arr.Length; i++){
                int ran = rand.Next(0,arr.Length);
                string temp = arr[i];
                arr[i] = arr[ran];
                arr[ran] = temp;
                Console.Write(arr[ran] + " ");
            }
            Console.WriteLine(" ");
            List<string> newArray = new List<string>();
             for(int i = 0; i < arr.Length; i++){
                 if( arr[i].Length > 5){
                     newArray.Add(arr[i]);
                 }
             }
             for(int i = 0; i < newArray.Count; i++){
                 Console.Write(newArray[i] + " ");
             }
             Console.WriteLine(" ");
        }
    }
}
