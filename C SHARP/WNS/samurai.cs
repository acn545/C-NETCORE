using System;
using System.Collections.Generic;


namespace WNS
{

    public class samurai : Human{
        public static int count = 0;
        public samurai() : base("samurai"){
            health = 200;
            count++;
        }
        public void death_blow(object obj){
            Human enemy  = obj as Human;
            int before = enemy.health;
            if(enemy.health <= 50){
                enemy.health = 0;
                Console.WriteLine("The Samurai dealtha Death_Blow, Enemies Health went from {0} to 0!!!", before);
            }else{
                Console.WriteLine("Death blow failed!, regualr attack damage delt");
                base.attack(obj);
            }
        }
        public void meditate(){
            Console.WriteLine("the Samurai entered a Meditative state and completely healed!!");
            health = 200;
        }
        public void how_many(){
            Console.WriteLine("there is currently {0} samurai", count);
        }
    }
}