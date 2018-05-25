using System;
using System.Collections.Generic;

namespace DeckofCards{

    public class Player{
        public string name;
        public List<Card> hand = new List<Card>(); 
        public Player(string player){
            name = player;
        }
        public void draw(Deck thisdeck){
            hand.Add(thisdeck.dealPlayer());
            Console.WriteLine("Drawing Card from Deck, current hand count is: {0}", hand.Count);
            Console.WriteLine("{0}'s Hand is: ", name);
            foreach(Card card in hand){
                Console.WriteLine("{0} is currently in hand",card.ToString());
            }
        }

        public Card discard(int cardnumber, Deck thisdeck){
            hand.RemoveAt(cardnumber);
            return null;
        }
    }
}