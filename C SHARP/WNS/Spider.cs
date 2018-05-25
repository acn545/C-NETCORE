using System;
using System.Collections.Generic;


namespace WNS
{
    public class Spider : Enemy{
        public Spider() : base("Zombie"){
            health = 100;
            strength = 2;
        }
        public void Scare(object obj){
            Human player = obj as Human;
            Random rand = new Random();
            int attack = strength * rand.Next(1,25);
            player.health -= attack;
            int injured = rand.Next(1,7) * strength;
            Console.WriteLine("a Spider has scared you, you injured yourself for {0} damage, but your instincts prevailed and you wailed in terror dealing {1} damage to the Spider", attack, injured);
            Console.WriteLine("{0}'s Health is now: {1}",player.name,  player.health);
        }
    }
}