using System;

namespace RockPaperScissorsSimulator // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main()
        {

            Console.WriteLine("Please enter number of rounds you want to play");
            int numberOfSimulations = getNumberOfRounds();

            int playerAPoints = 0;
            int playerBPoints = 0;

            for (int i = 1; i <= numberOfSimulations; i++)
            {
                Console.WriteLine("Round {0} Begins", i);
                Console.WriteLine("Please enter Rock, Paper or Scissor");

                //PlayerB always bets randomly
                var playerB = GetPlayerBAction();
                Console.WriteLine("PlayerB bets: {0}", playerB.ToString());

                //PlayerA always bets Stone!
                var playerA = Action.Rock;
                Console.WriteLine("PlayerA always Bets: {0}", playerA.ToString());

                //Play game and get results
                switch (playGame(playerB))
                {
                    case Result.PlayerBWon:
                        Console.WriteLine("PlayerB won the round! PlayerB gained a point.");
                        playerAPoints++;
                        break;
                    case Result.PlayerAWon:
                        Console.WriteLine("PlayerA won the round! PlayerA gained a point.");
                        playerBPoints++;
                        break;
                    case Result.Draw:
                        Console.WriteLine("Its a draw. PlayerA and the PlayerB gained a point.");
                        playerAPoints++;
                        playerBPoints++;
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Results -Rounds Played {0}, PlayerA {1}, PlayerB {2}", numberOfSimulations, playerAPoints, playerBPoints);
            if (playerAPoints == playerBPoints)
            {
                Console.WriteLine("Its a draw");
            }
            else
            {
                bool isPlayerWinner = playerAPoints > playerBPoints;
                Console.WriteLine("{0} won the game!", isPlayerWinner ? "PlayerA" : "PlayerB");
            }
        }

        // Method to enter number of rounds needs to play
        public static int getNumberOfRounds()
        {
            int result;
            do
            {
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please input a number.");
                }
            } while (true);
        }

        //Get Hand selections from Player A
        public static Action GetPlayerBAction()
        {
            Action result;
            do
            {
                var input = Console.ReadLine();
                if (Action.TryParse(input, true, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid action {0}. Please input 'Rock', 'Paper' or 'Scissors'.", input);
                }
            } while (true);
        }

        //Play game method
        public static Result playGame(Action playerB)
        {
            switch (playerB)
            {
                case Action.Rock:
                    return Result.Draw;
                case Action.Paper:
                    return Result.PlayerBWon;
                case Action.Scissor:
                    return Result.PlayerAWon;

            }

            throw new Exception(string.Format("Unhandled action pair occured: {0}", playerB));
        }
    }
}

//enum to get game actions
public enum Action { Rock, Paper, Scissor };

//Enum to get game results
public enum Result { Draw, PlayerAWon, PlayerBWon }