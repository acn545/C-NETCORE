using System;
using System.Collections.Generic;
namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> data = new List<object>();
            data.Add(7);
            data.Add(28);
            data.Add(-1);
            data.Add(true);
            data.Add("chair");
            int sum = 0;
            for(var i = 0; i < data.Count; i++ ){
                Console.WriteLine(data[i]);
                if(data[i] is int){
                 sum += (int)data[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
