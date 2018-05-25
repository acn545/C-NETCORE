using System;
using System.Collections.Generic;


namespace WNS
{
    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object obj)
        {
            Enemy enemy = obj as Enemy;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {   
                int before = enemy.health;
                enemy.health -= strength * 5;
                int after = enemy.health;
                Console.WriteLine("attack success, {2}'s hp went from {0} to {1}", before, after, enemy.name);
            }
        }
    }


}