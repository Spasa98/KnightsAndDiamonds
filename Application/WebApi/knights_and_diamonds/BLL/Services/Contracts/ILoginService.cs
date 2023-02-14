﻿using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Contracts
{
	public interface ILoginService
	{
		Task<TokenDTO> Login(UserInfoDTO user);
	}
}
