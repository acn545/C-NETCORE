using System;
using System.Collections.Generic;

namespace DeckofCards
{
 
 public class Deck{
        public int[] val = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
        public string[] stringVal = new string[] {"ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        public string[] suit = new string[] {"Clubs", "Spades", "Hearts", "Diamonds"};
        public List<Card> deck = new List<Card>(); 
        public Deck(){
            reset();
        }
        
        public Card deal(Player player){
            Console.WriteLine("Dealing 10 Cards to {0}'s Hand", player.name);
            for(int i = 0; i < 10; i++){
                Console.WriteLine("Card Dealt to hand: {0}", deck[i].ToString());
                Card temp = deck[i];
                player.hand.Add(temp);
                deck.RemoveAt(i);
             
            }
            Console.WriteLine("Cards left in the deck: {0}",deck.Count);
            return null;
        }
        public Card dealPlayer(){
            if(deck.Count > 0){
                Card temp = deck[0];
                deck.RemoveAt(0);
                return temp;
            }
            return null;
        }
        

        public Deck reset(){
            deck.Clear();
            for(int a = 0; a < suit.Length; a++){
                for(int b = 0; b < val.Length; b++){
                    string values = stringVal[b];
                    string suits = suit[a];
                    int number = val[b] +1 ;
                    Card card = new Card(suits, values, number);
                    deck.Add(card);
                 // Console.WriteLine("This Card is a {1} of {0}", suits, values);
                }
            }   
            Console.WriteLine("deck count " + deck.Count);
            return this;
        }

        public Deck shuffle(){
            Random rand = new Random();
            Console.WriteLine("Shuffling Deck....");
            for(int i = deck.Count -1 ; i > 0; i--){
                int ranNumber = rand.Next(i);
                Card temp = deck[ranNumber];
                deck[ranNumber] = deck[i];
                deck[i] = temp;
               // Console.WriteLine("This Card is a {0}", deck[i].ToString());
            }
            return this;
        }

    public override string ToString(){
        string info = "";
        foreach(Card card in deck){
            info+= card + "\n";
        }
        return info;
    }
        
    }
}