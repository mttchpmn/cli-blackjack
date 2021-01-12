using System;

namespace Blackjack
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("----------|  WELCOME TO BLACKJACK  |----------");

      string quit = "";
      // do
      // {
      var game = new Game();
      while (true)
      {
        game.Play();
        game.Reset();
      }
      // Console.WriteLine("\nYou are out of chips. Bye bye.");
      // Console.WriteLine("\nPress any key to exit. Press enter to play again.");
      // quit = Console.ReadLine();
    }
    // while (String.IsNullOrEmpty(quit));
  }
}
// }
