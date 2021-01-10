using System;

namespace Blackjack
{
  class ChipStack
  {
    public int Value { get; private set; }
    public ChipStack(int initialValue)
    {
      this.Value = initialValue;
    }

    public void Increase(int amount)
    {
      this.Value += amount;
    }

    public void Decrease(int amount)
    {
      this.Value -= amount;
    }


  }
}