using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Game
  {
    private Deck deck;
    public bool PlayerBust { get; private set; }
    public bool PlayerTurnComplete { get; private set; }
    public bool DealerBust { get; private set; }
    public bool DealerTurnComplete { get; private set; }
    public int PlayerScore { get; private set; }
    public int DealerScore { get; private set; }

    public Game()
    {
      this.PlayerBust = false;
      this.PlayerScore = 0;
      this.DealerScore = 0;

      this.deck = new Deck();
    }

    public void Play()
    {
      Console.WriteLine("Game starting...");
      this.DealToDealer(deck.Deal());
      this.PlayerLoop();
      if (!this.PlayerBust) this.DealerLoop();

      this.CheckWinner();
    }

    private void CheckWinner()
    {
      if (this.PlayerBust)
      {
        Console.WriteLine("Bust - you lose.");
      }
      else if (this.DealerBust)
      {
        Console.WriteLine("Dealer Bust - You win!");
      }
      else
      {
        int playerOffset = 21 - this.PlayerScore;
        int dealerOffset = 21 - this.DealerScore;

        string winner = (playerOffset < dealerOffset) ? "You win!" : "You lose.";

        Console.WriteLine(winner);
      }
    }

    private void PlayerLoop()
    {
      DealToPlayer(this.deck.Deal(2));
      CheckPlayerMove();
      while (!this.PlayerTurnComplete)
      {
        DealToPlayer(deck.Deal(1));
        if (this.PlayerScore > 21)
        {
          this.PlayerTurnComplete = true;
          this.PlayerBust = true;
          break;
        }
        CheckPlayerMove();
      }

    }

    private void DealerLoop()
    {
      while (this.DealerScore < 17) this.DealToDealer(deck.Deal());
      if (this.DealerScore > 21) this.DealerBust = true;
    }

    private void DealToPlayer(List<Card> deal)
    {
      foreach (Card card in deal)
      {
        Console.WriteLine($"You are dealt a {card}");
        this.PlayerScore += card.Value;
      }
      Console.WriteLine($"Your score is: {this.PlayerScore}");
    }

    private void DealToDealer(Card deal)
    {
      Console.WriteLine($"The dealer is dealt a {deal}");
      this.DealerScore += deal.Value;
      Console.WriteLine($"The dealer score is {this.DealerScore}");
    }

    private void CheckPlayerMove()
    {
      string ans = "";

      while (ans != "h" && ans != "s")
      {
        Console.WriteLine("Press h to hit, s to stand");
        ans = Console.ReadLine();
      }
      if (ans == "s") this.PlayerTurnComplete = true;
    }
  }
}