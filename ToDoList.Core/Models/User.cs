using System;
namespace ToDoList.Core.Models
{
	public class User : Entity
	{
		public string Name { get; set; }
		public string Avatar { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string SharingUrl { get; set; }
	}
}

