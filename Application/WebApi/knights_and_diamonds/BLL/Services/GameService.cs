﻿using BLL.Services.Contracts;
using DAL.DataContext;
using DAL.DTOs;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
    public struct ConnectionsPerUser
    {
        public List<string> MyConnections { get; set; }
		public List<string> EnemiesConnections { get; set; }
	}
	public class GameService : IGameService
    {
        private readonly KnightsAndDiamondsContext _context;
        public UnitOfWork _unitOfWork { get; set; }
        public IDeckService _deckService { get; set; }
        public IConnectionService _connectionService { get; set; }
		public ICardService _cardService { get; set; }



		public GameService(KnightsAndDiamondsContext context)
        {
            this._context = context;
            this._unitOfWork = new UnitOfWork(_context);
            this._deckService = new DeckService(_context);
			this._connectionService = new ConnectionService(_context);
            this._cardService = new CardService(_context);

		}

		public async Task<List<string>> GameGroup(int gameID)
        {
			var group = new List<string>();
			var game = await this._unitOfWork.Game.GetGameWithPlayers(gameID);
            if (game == null)
            {
                throw new Exception("There is no game with this ID");
            }
            foreach (var player in game.Players)
            {
				var connections = await this._connectionService.GetConnectionByUser(player.UserID);
                group.Concat(connections);
			}
            return group;
        }
		public async Task<ConnectionsPerUser> GameConnectionsPerPlayer(int gameID,int playerID)
		{
            var connectionsPerUser = new ConnectionsPerUser();
			var game = await this._unitOfWork.Game.GetGameWithPlayers(gameID);
			if (game == null)
            {
                throw new Exception("There is no game with this ID");
            }
			foreach (var player in game.Players)
			{
                    var connections = await this._connectionService.GetConnectionByUser(player.UserID);
                    if (player.ID == playerID)
                    {
                        connectionsPerUser.MyConnections = connections;
                    }
                    else
                    {
                        connectionsPerUser.EnemiesConnections = connections;
                    }
			}
			return connectionsPerUser;
		}
        
        public async Task<Game> GetGameByID(int gameID)
        {
            var game = await this._unitOfWork.Game.GetOne(gameID);
            if (game == null)
            {
                throw new Exception("There is no game with this ID");
            }
            return game;
        }
        public async Task SetGameStarted(Game game)
        {
            game.GameStarted = game.GameStarted+1;
            this._unitOfWork.Game.Update(game);
            this._unitOfWork.Complete();
        }
		public async Task<GameDTO> GetGame(int gameID, int userID)
		{
			GameDTO game = new GameDTO();
			var gaame = await this._unitOfWork.Game.GetGameWithPlayers(gameID);
			foreach (var player in gaame.Players)
			{
				if (player.UserID == userID)
				{
					game.PlayerID = player.ID;
					game.GameID = player.GameID;
				}
				else
				{
					game.EnemiePlayerID = player.ID;
				}
			}
			game.GameID = gaame.ID;
			return game;
		}

/*        public async Task<FieldDTO> GetPlayersField(int playerID)
        {
            var mappedCards = new List<CardDisplayDTO>();

			var player = await this.GetPlayersField(playerID);
            if (player == null)
            {
                throw new Exception("There is no player with this id");
            }
            if (player.Hand == null)
            {
                throw new Exception("This player has no hand");
            }
            if(player.CardFields == null)
            {
				throw new Exception("This player has no fields");
			}
            foreach (var card in player.Hand)
            {
                var mappedCard=await this._cardService.m
            }
		}*/

		public async Task<int> SetFirstGamesTurn(int rpsGameID,int gameID)
        {
            var rpsGame = await this._unitOfWork.RPSGame.GetOne(rpsGameID);
            if (rpsGame == null)
            {
                throw new Exception("There is no RPSgame with this ID");
            }
            if (rpsGame.Winner == 0)
            {
                throw new Exception("No one wins this game,there are some errors");
            }
            var game = await this._unitOfWork.Game.GetOne(gameID);
			if (game == null)
			{
                throw new Exception("There is no game with this ID");
			}
            game.PlayerOnTurn = rpsGame.Winner;
            this._unitOfWork.Game.Update(game);
            await this._unitOfWork.Complete();

			return game.PlayerOnTurn;
        }
        public async Task<Game> NewTurn(int gameID)
        {
            var game = await this._unitOfWork.Game.GetGameWithTurns(gameID);
			if (game == null)
			{
				throw new Exception("There is no game with this ID");
			}
            var turn = new Turn();
            game.NewTurn(turn);
            this._unitOfWork.Game.Update(game);
            await this._unitOfWork.Complete();
            return game;
		}

    }
}
