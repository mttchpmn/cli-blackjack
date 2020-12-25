using System;

namespace Blackjack
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("----------|  WELCOME TO BLACKJACK  |----------");

      Deck deck = new Deck();

      var deal1 = deck.Deal();
      var deal5 = deck.Deal(5);

      Console.WriteLine("Dealing one card...");
      Console.WriteLine($"Deal 1: {deal1}\n");

      Console.WriteLine("Dealing five cards...");
      foreach (Card c in deal5) Console.WriteLine(c);

      var inDeck = deck.CardsInDeck;
      var dealt = deck.CardsDealt;

      Console.WriteLine("\nIn deck:");
      foreach (Card c in inDeck) Console.WriteLine(c);

      Console.WriteLine("\nDealt:");
      foreach (Card c in dealt) Console.WriteLine(c);
    }
  }
}
