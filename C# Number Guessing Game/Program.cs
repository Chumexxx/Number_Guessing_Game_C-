bool playAgain = true;

while (playAgain)
{
    int randomNum, maxRange, attempts;
    string difficultyChoice, playAgainChoice;
    double guess;
    bool isCorrect = false;

    Console.Clear(); // Clears the console for a fresh start
    Console.WriteLine("C# Number Guessing Game");
    Console.WriteLine();
    Console.WriteLine("How to Play?");
    Console.WriteLine();
    Console.WriteLine("Guess a number and if your number is not correct, you can guess again.");
    Console.WriteLine();
    Console.WriteLine("The computer will provide hints after each guess as to whether the secret number is higher or lower than the number you have guessed.");
    Console.WriteLine();
    Console.WriteLine("Goodluck!");
    Console.WriteLine();
    Console.WriteLine("Select Difficulty Level: ");
    Console.WriteLine();
    Console.WriteLine("1. Easy: The range of your guesses will be between 1-10 ");
    Console.WriteLine("2. Medium: The range of your guesses will be between 1-50 ");
    Console.WriteLine("3. Hard: The range of your guesses will be between 1-100 ");
    Console.WriteLine();
    Console.Write("Enter your choice (1, 2, or 3): ");

    maxRange = 0;
    attempts = 0;
    difficultyChoice = Console.ReadLine();

    // Switch statements to check the difficulty level of the user
    switch (difficultyChoice)
    {
        case "1":
            maxRange = 10;
            break;
        case "2":
            maxRange = 50;
            break;
        case "3":
            maxRange = 100;
            break;
        default:
            Console.WriteLine("Invalid choice! Defaulting to Easy level.");
            maxRange = 10;
            break;
    }

    // Method for generating random numbers from a range
    Random random = new Random();
    randomNum = random.Next(1, maxRange + 1);

    Console.WriteLine($"I have selected a number between 1 and {maxRange}. Can you guess it?");

    // While loop to check if the user guesses too high, too low, or if they guess correctly
    while (!isCorrect)
    {
        attempts++;
        Console.Write("Enter your guess: ");
        try
        {
            guess = Convert.ToDouble(Console.ReadLine());

            if (guess < 1 || guess > maxRange)
            {
                Console.WriteLine($"Please enter a number between 1 and {maxRange}.");
                continue;
            }

            if (guess > randomNum)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else if (guess < randomNum)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else
            {
                isCorrect = true;
                Console.WriteLine($"Congratulations! You've guessed the correct number in {attempts} attempts.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    // Ask the user if they want to play again
    Console.WriteLine("Would you like to play again? (y/n)");
    playAgainChoice = Console.ReadLine().ToLower();

    if (playAgainChoice != "y")
    {
        playAgain = false;
        Console.WriteLine("Thank you for playing! Press any key to exit.");
        Console.ReadKey();
    }
}
