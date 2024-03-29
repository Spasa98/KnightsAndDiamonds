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
	public class EffectRepository : Repository<Effect>, IEffectRepository
	{
		public EffectRepository(KnightsAndDiamondsContext context) : base(context)
		{

		}
		public KnightsAndDiamondsContext? Context
		{
			get { return _context as KnightsAndDiamondsContext; }
		}

		public async Task<Effect?> GetEffectByDescription(string description)
		{
			var effect= await this.Context.Effects?.Where(x => x.Description == description).Include(x => x.EffectType).FirstOrDefaultAsync();
			return effect;
		}
		public async Task<EffectType> GetEffectType(int effectTypeID)
		{
			var effectType= await this.Context.EffectTypes.FindAsync(effectTypeID);
			if (effectType == null)
			{
				throw new Exception("There is no type with this ID");
			}
			return effectType;
		}
		public async Task<Effect> GetEffect(int effectID)
		{
			var effect=await this.Context.Effects?.Include(x=>x.EffectType).Where(x=>x.ID==effectID).FirstOrDefaultAsync();
			if (effect == null)
			{
				throw new Exception("There is no effect eith this ID");
			}
			return effect;
		}

		public async Task<IList<EffectType>> GetEffectTypes()
		{
			var effectTypes= await this.Context.EffectTypes?.ToListAsync();
			return effectTypes;
		}
	}
}
