﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DesignPatterns
{
	public sealed class OnlineUsers
	{
		private OnlineUsers()
		{
			ConnectedUsers = new Dictionary<int, List<string>>();
		}

		private static readonly object _lock = new object();
		private static OnlineUsers? _instance = null;

		public static OnlineUsers GetInstance()
		{
			if (_instance == null)
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new OnlineUsers();
					}
				}
			}
			return _instance;
		}
		public Dictionary<int,List<string>> ConnectedUsers { get; set; }
	}
}
