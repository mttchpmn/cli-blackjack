using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Player : IPlayer
  {
    public ChipStack Chips { get; set; }
    private int Bet { get; set; }

    public Hand Hand { get; }

    public int Score { get { return this.Hand.GetValue(); } }

    public Deck ActiveDeck { get; }

    public bool IsBust { get; set; }
    public bool IsTurnComplete { get; set; }


    public Player(Deck deck, int chipAmount = 100)
    {
      this.Chips = new ChipStack(chipAmount);
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

    public void MakeBet(int amount)
    {
      this.Bet = amount;
    }

    public void WinBet()
    {
      this.Bet = 0;
      this.Chips.Increase(this.Bet * 2);
    }

    public void LoseBet()
    {
      this.Bet = 0;
      this.Chips.Decrease(this.Bet);
    }
  }
}