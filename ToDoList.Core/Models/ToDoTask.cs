using System;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Core.Enums;

namespace ToDoList.Core.Models
{
	[Table("Tasks")]
	public class ToDoTask : Entity
	{
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }

		public string Name { get; set; }
		public TaskStatus Status { get; set; }
	}
}

