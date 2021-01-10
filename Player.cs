using System;

namespace Blackjack
{
  class Player
  {
    private ChipStack Chips { get; set; }

    private int Bet { get; set; }
    public Player()
    {
      this.Chips = new ChipStack(100);
    }

    public void MakeBet(int amount)
    {
      this.Bet = amount;
      this.Chips.Decrease(amount);
    }

    public void WinBet()
    {
      this.Bet = 0;
      this.Chips.Increase(this.Bet * 2);
    }

    public void LoseBet()
    {
      this.Bet = 0;
    }
  }
}