﻿using Interfaces.Games;
using Factories;
using Models;
using Models.Enums;
using System;

namespace Logic.Games
{
    public class GameLogic
    {
        private IGameRepository gameRepository;

        public GameLogic(IGameRepository repository = null)
        {
            gameRepository = repository ?? GameFactory.GetGameRepository();
        }

        public void AddMunchkin(Game game, Munchkin munchkin) => gameRepository.AddMunchkin(game, munchkin);

        public void RemoveMunchkin(Game game, Munchkin munchkin) => gameRepository.RemoveMunchkin(game, munchkin);

        public void SetWinner(Game game, Munchkin munchkin) => gameRepository.SetWinner(game, munchkin);

        public void AdjustGameStatus(Game game, GameStatus status) => gameRepository.AdjustGameStatus(game, status);

        public int RollDice() => new Random().Next(1, 7);
    }
}
