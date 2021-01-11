using System;

namespace Blackjack
{
  class Dealer : IPlayer
  {
    public Deck ActiveDeck { get; }
    public Hand Hand { get; }
    public int Score { get { return this.Hand.GetValue(); } }
    public bool IsBust { get; set; }
    public bool IsTurnComplete { get; set; }

    public Dealer(Deck deck)
    {
      this.ActiveDeck = deck;
      this.Hand = new Hand();
      this.IsBust = false;
      this.IsTurnComplete = false;
    }
    public void Hit()
    {
      var card = this.ActiveDeck.Deal();
      this.Hand.AddToHand(card);
      if (this.Score > 21) this.IsBust = true;
    }

    public void Stand()
    {
      this.IsTurnComplete = true;
    }
  }
}