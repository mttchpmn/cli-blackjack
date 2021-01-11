using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
  class Hand
  {
    private List<Card> cards;

    public void AddToHand(List<Card> cards)
    {
      this.cards.AddRange(cards);
    }

    public int GetValue()
    {
      return cards.Sum(x => x.Value);
    }

  }
}