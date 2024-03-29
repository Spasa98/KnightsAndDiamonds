﻿using DAL.DataContext;
using DAL.Models;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class TurnRepository:Repository<Turn>,ITurnRepository
	{
		public TurnRepository(KnightsAndDiamondsContext context) : base(context)
		{

		}
		public KnightsAndDiamondsContext? Context
		{
			get { return _context as KnightsAndDiamondsContext; }
		}

	}
}
