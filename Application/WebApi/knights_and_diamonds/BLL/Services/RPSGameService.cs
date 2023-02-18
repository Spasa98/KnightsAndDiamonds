﻿using BLL.Services.Contracts;
using DAL.DataContext;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DesignPatterns;
using System.Numerics;
using System.Collections;
using static System.Text.Json.JsonSerializer;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Services
{
	public class RPSGameService : IRPSGamaeService
	{
		private readonly KnightsAndDiamondsContext _context;
		public UnitOfWork unitOfWork { get; set; }
		private InGameUsers _usersingame { get; set; }
		public RPSGameService(KnightsAndDiamondsContext context)
		{
			this._context = context;
			unitOfWork = new UnitOfWork(_context);
			_usersingame = InGameUsers.GetInstance();
		}

		public async Task<int> NewLobby(OnlineUserDto user, OnlineUserDto challengedUser)
		{
			if (!this._usersingame.UsersInGame.Contains(user.ID) && !this._usersingame.UsersInGame.Contains(challengedUser.ID))
			{
				Lobby lobby;
				var lobbies = this._usersingame.Lobbies;

				if (lobbies.Any(x => x.User1.ID == user.ID && x.User2.ID == challengedUser.ID))
				{
					throw new Exception("You have allready challenged this player");
				}

                if (lobbies.Any(x => x.User1.ID == challengedUser.ID && x.User2.ID == user.ID))
                {
                    throw new Exception("This user allready challenged you");
                }

                int lobbyID = this._usersingame.lobbyID++;

                if (!lobbies.Any(x=>x.ID==lobbyID))
				{
					lobby = new Lobby(lobbyID, user, challengedUser);
					lobbies.Add(lobby);
				}

				else
				{
					throw new Exception("There is already lobby with this ID");
				}

				return lobby.ID;
			}
			else 
			{ 
				throw new Exception("One or both users are already in game");
			}
		}

		public async Task<int> StartGame(int lobbyID)
		{
			var lobbies = this._usersingame.Lobbies;

			if (!lobbies.Any(x => x.ID == lobbyID))
			{
				throw new Exception("There is no lobby with this ID");
			}

			Lobby lobby = lobbies.Find(x => x.ID == lobbyID);

			if (lobby.User1 == null && lobby.User2 == null)
			{
				throw new Exception("There is no users in this lobby");
			}

			RockPaperScissorsGame game = new RockPaperScissorsGame();
			this.unitOfWork.RPSGame.Add(game);

			var user1 = await this.unitOfWork.User.GetOne(lobby.User1.ID);
			var user2 = await this.unitOfWork.User.GetOne(lobby.User2.ID);

			Player player1 = new Player(game, user1);
			Player player2 = new Player(game, user2);

			this._usersingame.UsersInGame.Add(user1.ID);
			this._usersingame.UsersInGame.Add(user2.ID);

			this.unitOfWork.Player.Add(player1);
			this.unitOfWork.Player.Add(player2);
			this.unitOfWork.Complete();

			return game.ID;
		}
        public async Task<int> DenyGame(int lobbyID)
        {
            var lobbies = this._usersingame.Lobbies;

            if (!lobbies.Any(x => x.ID == lobbyID))
            {
                throw new Exception("There is no lobby with this ID");
            }

            Lobby lobby = lobbies.Find(x => x.ID == lobbyID);

            lobbies.Remove(lobby);

            return lobby.ID;
        }
        public async Task<Dictionary<int,List<int>>> GetGames()
		{
			try
			{
				return this._usersingame.GamesIDs;
			}
			catch
			{
				throw;
			}
		}
		public async Task<List<int>> RedirectToGame(int gameID) 
		{
			List<int> usersIDs=new List<int>(); 
			var game = await this.unitOfWork.RPSGame.GetGamesWithPlayers(gameID);
			if (game == null)
			{
				throw new Exception("There is no game with this ID");
			}
		
			foreach (var player in game.Players)
			{
				usersIDs.Add(player.UserID);
			}
			return usersIDs;
		}
		public async Task<List<Lobby>> LobbiesPerUser(int userID)
		{
			var lobbies = this._usersingame.Lobbies.Where(x => x.User2.ID == userID).ToList();
			return (lobbies);
		}

	}
}