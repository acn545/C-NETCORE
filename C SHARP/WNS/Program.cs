using System;

namespace WNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard1 = new Wizard();
            Ninja ninja1 = new Ninja();
            samurai sam1 = new samurai();
            Zombie zom1 = new Zombie();
            Zombie zom2 = new Zombie();
            Spider spider = new Spider();
            int encounter =1;
            zom1.health = 0;
            Console.WriteLine("To get to your destination you must travel 10 times without dieing");
            while(encounter <= 10){
                    if(zom1.health > 0){
                         Console.WriteLine("Please type your attack below: ");
                            string Inputline = Console.ReadLine();
                            if(Inputline == "Ninja Steal"){
                                ninja1.Steal(zom1);
                                if(zom1.health > 0){
                                    zom1.Feed(ninja1);

                                }else{
                                    encounter ++;
                                    Console.WriteLine("The Zombies Health is gone YOU WIN!!");
                                    Console.WriteLine("You made it to the next destination safely!!"); 
                                }
                            }

                    }else{
                        Console.WriteLine("Would you like to travel to the Left or Right along the path? : " );
                        string Inputpath = Console.ReadLine();
                        Random rand = new Random();
                        if(Inputpath == "Right" || Inputpath == "Left"){
                            Console.WriteLine("you have traveled a distance of {0}", encounter);
                            if(rand.Next(0,10) < 7){
                                Console.WriteLine("A Zombie has appeared and attacked!!");
                                zom1.health = 50;
                                Console.WriteLine("Please type your attack below: ");
                                string Inputline = Console.ReadLine();
                                if(Inputline == "Ninja Steal"){
                                    ninja1.Steal(zom1);
                                    if(zom1.health > 0){
                                        if(ninja1.health <= 0){
                                            encounter =10;
                                            Console.WriteLine("The Ninja's Health is gone GAME OVER");
                                         }
                                        zom1.Feed(ninja1);
                                    }else{
                                        encounter ++;
                                        Console.WriteLine("The Zombies Health is gone YOU WIN!!");
                                        Console.WriteLine("You made it to the next destination safely!!"); 
                                    }
                                }
                            }else{
                                encounter ++;
                                Console.WriteLine("You made it to the next destination safely!!");
                            }
                        }
                    if(ninja1.health <= 0){
                            encounter =11;
                            Console.WriteLine("The Ninja's Health is gone GAME OVER");
                    }
                }
            }
            Console.WriteLine("GAME OVER");
        }
    }
}
