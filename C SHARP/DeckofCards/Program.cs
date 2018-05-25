using System;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            Player player1 = new Player("Anthony");
            deck1.shuffle();
            deck1.deal(player1);
            player1.draw(deck1);
        }
    }
}
