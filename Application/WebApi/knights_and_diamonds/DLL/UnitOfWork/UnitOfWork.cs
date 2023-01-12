﻿using DAL.DataContext;
using DAL.Repositories;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly KnightsAndDiamondsContext _context;

		public UnitOfWork(KnightsAndDiamondsContext context)
		{
			_context = context;
			Card = new CardRepository(_context);
		}

		public ICardRepository Card { get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}