﻿using Models;
using Logic.Games;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult Index()
        {
            User user = JsonConvert.DeserializeObject<User>(Request.Cookies["LoggedInUser"]);
            ViewBag.LoggedInUser = user;

            Game game = new Game();
            gameCollectionLogic.AddGame(game);

            ViewBag.ActiveGame = game;

            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}