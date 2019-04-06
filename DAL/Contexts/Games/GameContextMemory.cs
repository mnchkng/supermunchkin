﻿using System.Collections.Generic;
using DAL.Interfaces.Games;
using Database;
using Models;
using Models.Enums;

namespace DAL.Contexts.Games
{
    public class GameContextMemory : IGameContext
    {
        private Memory memory = new Memory();

        public void AddGame(Game game)
        {
            //Add game
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            //Add munchkin
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            //Adjust gamestatus
        }

        public IEnumerable<Game> GetAllGames()
        {
            return memory.GetAllGames();
        }

        public Game GetGameById(int id)
        {
            return memory.GetGameById(id);
        }

        public void RemoveMunchkin(Game game, Munchkin munchkin)
        {
            //Remove munchkin
        }

        public void SetWinner(Game game, Munchkin munchkin)
        {
            //Set winner
        }
    }
}