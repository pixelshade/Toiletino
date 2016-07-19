using System;
using System.Collections.Generic;
using GameKit;
namespace toiletino
{
	public class User
	{
		public Guid Guid;
		public string Username;
		public string Email;
		public bool Superuser;
		public string FbToken;
		public string GoogleToken;
		public string TwitterToken;
		public List<Achievement> Achievements = new List<Achievement>();

		public User()
		{
		}
	}
}

