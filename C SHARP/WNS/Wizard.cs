using System;
using System.Collections.Generic;


namespace WNS
{
    public class Wizard: Human{

        public Wizard() : base("Wizard"){
            intelligence = 25;
            health = 50;
        }
        public void Heal(){
            health += intelligence * 10;
            int amount = intelligence * 10;
            Console.WriteLine("{0} has been healed for {1} to {2} health", name, amount, health);
        }
        public void FireBall(object obj){
            Random rand = new Random();
            Human enemy = obj as Human;
            if(enemy == null){
                    Console.WriteLine("Failed Attack");
                }
                else
                {
                    int before = enemy.health;
                    enemy.health -= rand.Next(20,50);
                    int after = enemy.health;
                    Console.WriteLine("FireBall success, {2}'s hp went from {0} to {1}", before, after, enemy.name);
            }
        }
    }
}
