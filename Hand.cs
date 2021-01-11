using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
  class Hand
  {
    private List<Card> Cards { get; }

    public Hand()
    {
      this.Cards = new List<Card>();
    }

    public void AddToHand(List<Card> cards)
    {
      this.Cards.AddRange(cards);
    }

    public int GetValue()
    {
      // return 1000;
      return Cards.Sum(x => x.Value);
    }

  }
}