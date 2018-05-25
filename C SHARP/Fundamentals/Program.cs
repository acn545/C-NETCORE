using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //displays all numbers between 1 and 255
            for(int i = 1; i <= 255; i++){
                Console.WriteLine(i);
            }
            // displays all numbers divisable by 3 or 5 but not both
            for(int i =1; i<=100;i++){
                if(i%3 == 0 || i%5 == 0){
                    if(i%3 == 0 && i%5 == 0){
                        continue;
                    }
                    else{
                        Console.WriteLine(i);
                    }
                }
            }
            //displays Fizz is divisable by 3 Buzz if by 5 and fizzbuzz for both
            for(int i =1; i<=100;i++){
                if(i%3 == 0 && i%5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(i%3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if(i%5 == 0){
                    Console.WriteLine("Buzz");
                }    
            }
            Console.WriteLine("BREAK BREAK BREAK");
            // without modulus
            for(int i =1; i<=100;i++){
                float num = (float)i/3;
                float num2 = (float)i/5;
                string three =num.ToString();
                string five =num2.ToString();
                if(five.Length < 3 && three.Length < 3){
                    Console.WriteLine("FizzBuzz");
                }
                else if(three.Length < 3){
                    Console.WriteLine("Fizz");
                }
                else if(five.Length < 3){
                    Console.WriteLine("Buzz");
                }
            }
            Console.WriteLine("BREAK BREAK BREAK");
            for(int i = 1; i <=10; i++){
              int rnum = rand.Next(1, 100);
              if(rnum%3 == 0 && rnum%5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(rnum%3 == 0){
                    Console.WriteLine("Fizz");
                }
                else if(rnum%5 == 0){
                    Console.WriteLine("Buzz");
                }
            }

        }
    }
}
