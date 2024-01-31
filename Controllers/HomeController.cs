using Microsoft.AspNetCore.Mvc;
using NumberGuesser.Models;
using System.Diagnostics;

namespace NumberGuesser.Controllers
{
    public class HomeController : Controller
    {
        private Game game;

        public HomeController()
        {
            game = new Game();
        }

        public ActionResult Index(GuessModel model = null)
        {
            ViewBag.Message = "Welcome to the Number Guesser game";
            return View(model);
        }

        [HttpPost]
        public ActionResult StartNewGame(int minRange, int maxRange)
        {
            // Validate input or handle errors as needed
            if (minRange >= maxRange)
            {
                ViewBag.Message = "Invalid range. Please ensure that the min range is less than the max range.";
                return View("Index");
            }

            game.StartNewGame(minRange, maxRange);
            var model = new GuessModel { GuessFormVisible = true }; // Set to true to show the guess form
            ViewBag.Message = $"New game started. Guess a number between {minRange} and {maxRange}.";
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult MakeGuess(GuessModel model)
        {
            bool isCorrect = game.MakeGuess(model.Guess);

            if (isCorrect || game.IsGameOver())
            {
                ViewBag.Message = $"Game Over. You guessed the correct number in {game.Attempts} attempts.";
                // You might want to reset the game or perform other actions here
            }
            else
            {
                ViewBag.Message = "Incorrect guess. Try again.";
                model.GuessFormVisible = true; // Set to true to keep the guess form visible after an incorrect guess
            }

            return View("Index", model);
        }

    }



}