using MostSnake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MostSnake.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Game()
        {
            List<Snake> list = new List<Snake>();
            Match match = new Match(list);
            return View(match);
        }

        public ActionResult RunMatch()
        {
            var match = GameLogic.RunMatch();
            ViewBag.Message = Winner(match);
            return View("game", match);
        }

        private string Winner(Match match)
        {
            string winner = "";
            switch (match.MatchWinner)
            {
                case 1:
                    winner = "The winner is the yellow snake!";
                    break;
                case 2:
                    winner = "The winner is the red snake!";
                    break;
                case 3:
                    winner = "The winner is the green snake!";
                    break;
                case 4:
                    winner = "The winner is the blue snake!";
                    break;
            }
            return winner;
        }
    }
}