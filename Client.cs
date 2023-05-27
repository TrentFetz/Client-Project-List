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
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime openDate { get; set;}
		public DateTime closedDate { get; set;}
		public bool isActive { get; set;}
		
		

		public override string ToString()
		{
			return $"ID:{ID}. Name:{Name}. \n Account Active:{isActive}. \n Notes:{Note} \n" +
				$"Open Date:{openDate.ToString("yyyy-MM-dd")} Close Date: {closedDate.ToString("yyyy-MM-dd")}";
		}
	}
}
