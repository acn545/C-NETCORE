using System;
using System.Collections.Generic;

namespace WNS{
    public class Enemy{
        public int health {get; set;}
        public int strength {get; set;}

        public string name;

        public Enemy(string evilname){
            name = evilname;
            strength = 5;
            health = 20;
        }
        public Enemy(string evilname, int str, int hp){
            name = evilname;
            strength = str;
            health = hp;
        }

        public void attack(object obj){
            Human player = obj as Human;
            Random rand = new Random();
            int chance = rand.Next(0,10);
            if(chance > 5){
                int attack = strength;
                player.health -= attack;
                int after = player.health;
                Console.WriteLine("The {0} attacked player {1} for {2} damage", name, player.name, attack);
                Console.WriteLine("{0} now has {1} hp left", player.name, after);
            }else{
                Console.WriteLine("The {0} missed its attack on {1}", name, player.name);
            }
        }
    }
}