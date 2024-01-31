using Microsoft.AspNetCore.Mvc;
using NumberGuesser.Models;
using System.Diagnostics;

namespace NumberGuesser.Controllers
{
    // HomeController.cs
    public class HomeController : Controller
    {
        private Game game;

        public HomeController()
        {
            game = new Game();
        }

        public ActionResult Index()
        {
            // Initialize the game when the page is loaded
            game.StartNewGame(1, 100);
            ViewBag.Message = "Welcome to the Number Guesser game!";
            return View();
        }

        [HttpPost]
        public ActionResult MakeGuess(int guess)
        {
            bool isCorrect = game.MakeGuess(guess);

            if (isCorrect || game.IsGameOver())
            {
                ViewBag.Message = $"Game Over. You guessed the correct number in {game.Attempts} attempts.";
            }
            else
            {
                ViewBag.Message = "Incorrect guess. Try again.";
            }

            return View("Index");
        }
    }

}