using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
  class Hand
  {
    public List<Card> Cards { get; private set; }

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
      return Cards.Sum(x => x.Value);
    }

    public void Discard()
    {
      this.Cards.Clear();
    }

  }
}