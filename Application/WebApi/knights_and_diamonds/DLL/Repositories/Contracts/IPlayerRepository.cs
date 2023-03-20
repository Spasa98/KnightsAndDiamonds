﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
	public interface IPlayerRepository : IRepository<Player>
	{
		Task<Player> GetPlayer(int gameID, int userID);
		Task<Player> GetPlayerByID(int playerID);
		Task<Player> GetPlayersHandByPlayerID(int playerID);
		Task<PlayersHand> GetPlayersHand(int playerID);
	}
}
