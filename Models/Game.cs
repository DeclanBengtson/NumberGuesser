namespace NumberGuesser.Models
{
    // Game.cs
    public class Game
    {
        private int targetNumber;
        private int attempts;
        private bool isGameOver;

        // Property to get the number of attempts
        public int Attempts
        {
            get { return attempts; }
        }

        public void StartNewGame(int minRange, int maxRange)
        {
            // Initialize the game state
            Random random = new Random();
            targetNumber = random.Next(minRange, maxRange + 1);
            attempts = 0;
            isGameOver = false;
        }

        public bool MakeGuess(int guess)
        {
            if (isGameOver)
            {
                return false; // The game is already over.
            }

            attempts++;

            if (guess == targetNumber)
            {
                isGameOver = true;
                return true; // Correct guess
            }
            else
            {
                return false; // Incorrect guess
            }
        }

        public bool IsGameOver()
        {
            return isGameOver;
        }
    }


}
