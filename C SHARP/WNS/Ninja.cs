using System;
using System.Collections.Generic;


namespace WNS
{
    public class Ninja : Human{
        public Ninja() : base("Ninja"){
            dexterity = 175;
        }

        public void Steal(object obj){
            Enemy enemy = obj as Enemy;
            base.attack(obj);
            health += 10;
            Console.WriteLine("{0} was healed for 10 health", name);

        }

        public void get_away(){
            health -= 15;
            
        }
    }
}