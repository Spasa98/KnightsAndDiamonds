﻿using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		ICardRepository Card { get; }
		IDeckRepository Deck { get; }
		IUserRepository User { get; }
		IRPSGameRepository RPSGame { get; }
		ICardInDeckRepository CardInDeck { get; }
		IPlayerRepository Player { get; }
		IGameRepository Game { get; }
		IEffectRepository Effect { get; }
		ITurnRepository Turn { get; }
		IGraveRepository Grave { get; }
		ICardFieldRepository CardField { get; }
		IAttackInTurnRepository AttackInTurn { get; }
		IPlayerHandRepository PlayerHand { get; }

		Task Complete();
	}
}
