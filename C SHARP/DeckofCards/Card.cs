using System;
using System.Collections.Generic;
namespace DeckofCards
{
    public class Card{
        public string cardSuit;
        public string cardValue;
        public int val;
        public Card(string suit, string value, int number){
           cardSuit = suit;
           cardValue = value;
           val= number;
        }
        public override string ToString(){
            return cardValue + " of " + cardSuit;
        }
    }


   

}