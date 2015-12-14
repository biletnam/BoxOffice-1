using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class View_Ticket
	{
		// propriedades (prop... / propfull...)
		public DateTime Date { get; set; }

		public int IdScreen { get; set; }

		public string ScreenName { get; set; }

		public int Row { get; set; }

		public int Number { get; set; }

		public bool Disability { get; set; }

		public int IdMovie { get; set; }

		public string Title { get; set; }

		public TimeSpan StartTime { get; set; }

		public int Runtime { get; set; }

		public int? IdClient { get; set; }

		public string ClientName { get; set; }

		public string ClientContact { get; set; }
	}
}
