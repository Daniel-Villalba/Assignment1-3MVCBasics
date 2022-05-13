using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCBasics.Models;
using System;

namespace MVCBasics.Controllers
{
    public class GuessingGameController : Controller
    {
        
        /*public IActionResult Index()
        {
            return View();
        }*/

        

        public IActionResult GuessingGame()
        {
            Random rnd = new Random();
            int secretNumber = rnd.Next(1, 101);
            HttpContext.Session.SetInt32("session", secretNumber);
            ViewBag.Message = GuessingGameModel.WriteMessage();
            return View();
        }
        [HttpPost]
        public IActionResult GuessingGame(int guessedNumber)
        {
            int correctNumber = (int)HttpContext.Session.GetInt32("session");
            ViewBag.Message = GuessingGameModel.CheckNumber(HttpContext.Session, correctNumber, guessedNumber);    
            return View();
        }
        
    }
}
