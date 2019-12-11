using System;

namespace guess_my_number
{
  class Program
  {
    public static int guessNumberBetween(int x, int y)
    {
      return (x + y) / 2;
    }

    static void Main(string[] args)
    {
      int lowerLimit = 1;
      int upperLimit = 100;
      int newGuess;
      ConsoleKeyInfo userResponse;
      int noOfGuesses = 0;
      int corrector;

      Console.WriteLine();
      Console.WriteLine("Think of a number between 1 and 100 and let me guess it.");
      do
      {
        noOfGuesses++;
        newGuess = guessNumberBetween(lowerLimit, upperLimit);
        if (noOfGuesses == 7)
        {
          Console.WriteLine($"Your number is {newGuess}.");
          break;
        }

        Console.Write("Guess #{0:N0}. ", noOfGuesses);
        if (noOfGuesses == 1)
        {
          Console.Write($"If your number is {newGuess}, press \"Y\"! If it is lower, press \"L\", if higher, press \"H\': ");
        }
        else
        {
          Console.Write($"Is your number {newGuess} (h)igher/(l)ower/(y)es? ");
        }
        userResponse = Console.ReadKey();
        Console.WriteLine();
        while ("hly".IndexOf(userResponse.Key.ToString().ToLower()) < 0)
        {
          Console.Write("That's not an accepted response. Try again: ");
          userResponse = Console.ReadKey();
          Console.WriteLine();
        }
        switch (userResponse.Key.ToString().ToLower())
        {
          case "h":
            lowerLimit = newGuess + 1;
            break;
          case "l":
            upperLimit = newGuess - 1;
            break;
          default: break;
        }
      } while (userResponse.Key.ToString().ToLower() != "y");

      corrector = (noOfGuesses == 7 ? 1 : 0);
      Console.WriteLine($"It took {noOfGuesses - corrector} tr" + (noOfGuesses == 1 ? "y" : "ies") + " to guess your number.");
      Console.WriteLine();

    }
  }
}
