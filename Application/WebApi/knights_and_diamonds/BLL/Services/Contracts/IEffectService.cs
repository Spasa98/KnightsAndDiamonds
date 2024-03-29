﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
	public interface IEffectService
	{
		Task<IList<EffectType>> GetEffectTypes();
		Task<EffectType> GetEffectTypeByID(int effectTypeID);
		Task<int> GetAreaOfClickingAfterPlayCard(int effectTypeID);

	}
}
