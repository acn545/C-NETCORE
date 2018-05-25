using System;
using System.Collections.Generic;


namespace WNS
{
    public class Zombie : Enemy{
        public Zombie() : base("Zombie"){
            health = 50;
            strength = 10;
        }
        public void Feed(object obj){
            Human player = obj as Human;
            Random rand = new Random();
            int attack = strength * rand.Next(1,3);
            player.health -= attack;
            health += attack / 2;
            Console.WriteLine("a Zombie Feeds on {0}'s Flesh dealing {1} damage and healing itself for {2}", player.name, attack, attack / 2);
            Console.WriteLine("{0}'s Health is now: {1}",player.name,  player.health);
        }
    }
}
