using System;
using System.Linq;
using System.Collections.Generic;

namespace Blackjack
{
  class Card
  {
    public int Value { get; private set; }
    public string Suit { get; private set; }
    public string Face { get; private set; }

    public Card(int value, string suit, string face = "")
    {
      this.Value = value;
      this.Suit = suit;
      this.Face = face;
    }

    public override string ToString()
    {
      string value = (String.IsNullOrEmpty(this.Face)) ? this.Value.ToString() : this.Face;

      return $"{value} of {this.Suit}";
    }

  }

}