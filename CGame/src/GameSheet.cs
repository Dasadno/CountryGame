using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryGame
{
    public class GameSheet
    {
        private static GameSheet _instance;
        protected GameSheet() { }
        public static GameSheet getInstance()
        {
            if (_instance == null)
                _instance = new GameSheet();
            return _instance;
        }

        public void GameSheetMethod(Game game)
        {
            if (game.LastWord == null)
            {
                game.LastWord = "Russia";
            }
            CheckLives(game);
            Console.Clear();
            Console.WriteLine
                ($"Current word: {game.LastWord}\n" +
                $"Current letter: {game.CurrentLetter}\n" +
                $"Move of the game: {game.MoveOrder}\n" +
                $"Player must move: {game.PlayersList[game.MoveOrder].Name}\n\n\n" +
                $"1. All players sheet\n" + 
                $"2. Finish the game\n" +
                $"Enter: ");

            game.PlayersList[game.MoveOrder].Answer = Convert.ToString(Console.ReadLine());
            string answer = game.PlayersList[game.MoveOrder].Answer;


            if (game.PlayersList[game.MoveOrder].Answer == "1")
            {
                game.PlayersSheet();
            }
            else if (game.PlayersList[game.MoveOrder].Answer == "2")
            {

            }
            else if (!IsAnswerRight(game.PlayersList[game.MoveOrder].Answer, game))
            {
                game.PlayersList[game.MoveOrder].Lives--;
                Console.WriteLine("\nNice try!");
                game.PlayersList[game.MoveOrder].Answer = null;
                Thread.Sleep(1500);
                Console.Clear();
                GameSheetMethod(game);
            }
            else if (IsAnswerRight(game.PlayersList[game.MoveOrder].Answer, game))
            {
                Console.WriteLine("It's right!");
                game.PlayersList[game.MoveOrder].Answer = null;
                Thread.Sleep(1500);
                Console.Clear();
                if (game.MoveOrder == game.PlayersList.Count)
                {
                    game.MoveOrder = 1;
                }
            }


        }

        public bool IsAnswerRight(string answer, Game game)
        {
            
            foreach (var country in game.CountryList)
            {
                string lowerAnsw = answer.ToLower();

                if (country.Name.ToLower() == lowerAnsw && lowerAnsw[0] == game.CurrentLetter)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckLives(Game game)
        {

            if (game.PlayersList[game.MoveOrder].Lives <= 0)
            {
                game.PlayersList[game.MoveOrder].Lives = 2;
                game.MoveOrder++;
            }
        }
    }
}
