﻿using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
	public interface IUnitOfWork:IDisposable
	{
		ICardRepository Card { get; }
		int Complete();
	}
}