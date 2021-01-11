using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Deck
  {
    public List<Card> CardsInDeck { get; private set; }
    public Deck()
    {
      this.CardsInDeck = Deck.BuildDeck();
      this.Shuffle();
    }
    private static List<Card> BuildDeck()
    {
      List<Card> result = new List<Card>();

      result.AddRange(Deck.BuildSuit("clubs"));
      result.AddRange(Deck.BuildSuit("spades"));
      result.AddRange(Deck.BuildSuit("hearts"));
      result.AddRange(Deck.BuildSuit("diamonds"));

      return result;
    }

    private static List<Card> BuildSuit(string suit)
    {
      var result = new List<Card>();

      // Add pip cards
      for (int i = 1; i <= 10; i++)
      {
        result.Add(new Card(i, suit));
      }
      // Add face cards
      result.Add(new Card(10, suit, "jack"));
      result.Add(new Card(10, suit, "queen"));
      result.Add(new Card(10, suit, "king"));

      return result;
    }

    public void Reset()
    {
      this.CardsInDeck = Deck.BuildDeck();
      this.Shuffle();
    }

    // Shuffle Deck using Fisher-Yates Algorithm
    public void Shuffle()
    {
      var rng = new Random();

      var deck = this.CardsInDeck;
      int n = deck.Count;

      while (n > 1)
      {
        n--;
        int k = rng.Next(n + 1);
        Card val = deck[k];
        deck[k] = deck[n];
        deck[n] = val;
      }
    }
    public List<Card> Deal(int numToDeal = 1)
    {
      int idx = this.CardsInDeck.Count - 1 - numToDeal;
      var cardsToDeal = this.CardsInDeck.GetRange(idx, numToDeal);
      this.CardsInDeck.RemoveRange(idx, numToDeal);

      return cardsToDeal;
    }
  }
}