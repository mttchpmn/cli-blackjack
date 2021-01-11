using System;
using System.Collections.Generic;

namespace Blackjack
{
  class Game
  {
    private Deck Deck { get; }
    private Player Player { get; }
    private Dealer Dealer { get; }

    public Game()
    {
      Deck = new Deck();
      Player = new Player(Deck, 200);
      Dealer = new Dealer(Deck);
    }

    public void Play()
    {
      Console.WriteLine("Game starting...");

      // Make bet
      Console.WriteLine("Enter your bet:");
      string input = Console.ReadLine();
      Player.MakeBet(Int32.Parse(input));

      // Deal cards
      Player.Hand.AddToHand(Deck.Deal(2));
      Dealer.Hand.AddToHand(Deck.Deal(1));

      // Show Dealer hand
      Console.WriteLine($"The Dealer has {Dealer.Score}");

      // Loop for Player
      while (!Player.IsTurnComplete)
      {
        Console.WriteLine($"Your score is {Player.Score}");

        if (Player.IsBust)
        {
          Console.WriteLine("Bust - You lose.");
          Player.LoseBet();
          break; // FIXME - Doesn't break the loop
        }

        Console.WriteLine("Do you want to [h]it or [s]tand?");
        var ans = Console.ReadLine();
        if (ans == "h")
        {
          Player.Hit();
        }
        else
        {
          Player.Stand();
        }
      }
      Console.WriteLine($"You stand on {Player.Score}");

      // Loop for Dealer
      while (!Dealer.IsTurnComplete)
      {
        Console.WriteLine($"The Dealer has {Dealer.Score}");

        if (Dealer.IsBust)
        {
          Console.WriteLine("Dealer bust - you win!");
          Player.WinBet();
          break;
        }

        if (Dealer.Score < 17)
        {
          Dealer.Hit();
        }
        else
        {
          Dealer.Stand();
        }
      }

      // Evaluate Winner
      if (Player.Score > Dealer.Score)
      {
        Console.WriteLine($"Your score of {Player.Score} beats the Dealer's {Dealer.Score} - You win!");
        Player.WinBet();
      }
      else if (Dealer.Score == Player.Score)
      {
        Console.WriteLine("Push!");
      }
      else
      {
        Console.WriteLine($"The Dealer's score of {Dealer.Score} beats your {Player.Score} - You lose.");
        Player.LoseBet();
      }

      // Log chips
      Console.WriteLine($"Player chips: {Player.Chips.Value}");

    }
  }
}