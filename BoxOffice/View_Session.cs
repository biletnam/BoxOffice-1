using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class View_Session
	{
		// propriedades (prop... / propfull...)
		public string Title { get; set; }

		public int Runtime { get; set; }

		public string Name { get; set; }

		public int NumberOfSeats { get; set; }

		public int IdMovie { get; set; }

		public int IdScreen { get; set; }

		public DateTime Date { get; set; }

		public TimeSpan StartTime { get; set; }
	}
}
