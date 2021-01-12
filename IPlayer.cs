using System;

namespace Blackjack
{
  interface IPlayer
  {
    public Deck ActiveDeck { get; }
    public Hand Hand { get; }
    public int Score { get; }
    public bool IsBust { get; set; }
    public bool IsTurnComplete { get; set; }
    void Hit();

    void Stand();

    void Reset();
  }
}