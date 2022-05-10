using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Models;

namespace ToDoList.Core
{
	public class ToDoListContext : DbContext
	{
        public DbSet<User> Users { get; set; }
		public DbSet<ToDoTask> Tasks { get; set; }

		public ToDoListContext(DbContextOptions options) : base(options)
		{
			
		}
	}
}

