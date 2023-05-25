using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.CLI.Models
{
	public class Client
	{
		public int ID { get; set;}
		public DateTime openDate { get; set;}
		public DateTime closedDate { get; set;}
		public bool isActive { get; set;}
		public string name { get; set;}
		public string note { get; set;}

		public override string ToString()
		{
			return $"{ID}. {name}";
		}
	}
}
