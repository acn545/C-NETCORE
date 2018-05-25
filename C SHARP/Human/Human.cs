using System;

namespace Human
{

    public class Human{

        public string name;
        public int str = 3;
        public int dex = 3;
        public int health = 100;
        public int intel = 3;
        public Human(string names){
            name = names;
        }
        public Human(string names, int strength, int dexterity, int intelligence, int healths){
            str = strength;
            name = names;
            dex = dexterity;
            intel = intelligence;
            health = healths;

        }

        public void Attack(object humans){
            Human enemy = humans as Human;
             if(enemy != null) {
                enemy.health -= 5 * str;
            }
            
        }
    }



}