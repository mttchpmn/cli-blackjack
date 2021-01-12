using System;

namespace Blackjack
{
  class Game
  {
    private Deck Deck { get; }
    private Player Player { get; }
    private Dealer Dealer { get; }

    private int GameCounter { get; set; }

    public Game()
    {
      Deck = new Deck();
      Player = new Player(Deck, 200);
      Dealer = new Dealer(Deck);
    }

    public void Reset()
    {
      Player.Reset();
      Dealer.Reset();
    }

    public void Play()
    {
      Console.WriteLine("\nGame starting...");

      // Make bet
      Console.WriteLine($"Your chips: {Player.Chips.Value}");
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

        if (Player.IsBust) break;

        Console.WriteLine("Do you want to [h]it or [s]tand?");
        var ans = Console.ReadLine();
        if (ans == "h")
        {
          Player.Hit();
        }
        else
        {
          Player.Stand();
          Console.WriteLine($"You stand on {Player.Score}");
        }
      }

      // Loop for Dealer
      while (!Dealer.IsTurnComplete && !Player.IsBust)
      {
        Console.WriteLine($"The Dealer is on {Dealer.Score}");

        if (Dealer.IsBust) break;

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
      if (Player.IsBust)
      {
        Console.WriteLine("Bust - You lose.");
        Player.LoseBet();
        Console.WriteLine($"Your chips: {Player.Chips.Value}");

        return;
      }

      if (Dealer.IsBust)
      {
        Console.WriteLine("Dealer bust - You win!");
        Player.WinBet();
        Console.WriteLine($"Your chips: {Player.Chips.Value}");

        return;
      }

      if (Player.Score > Dealer.Score)
      {
        Console.WriteLine($"Your score of {Player.Score} beats the Dealer's {Dealer.Score} - You win!");
        Player.WinBet();
        Console.WriteLine($"Your chips: {Player.Chips.Value}");

        return;
      }
      else if (Dealer.Score == Player.Score)
      {
        Console.WriteLine("Push!");

        return;
      }
      else
      {
        Console.WriteLine($"The Dealer's score of {Dealer.Score} beats your {Player.Score} - You lose.");
        Player.LoseBet();
        Console.WriteLine($"Your chips: {Player.Chips.Value}");

        return;
      }

      // Log chips

    }
  }
}