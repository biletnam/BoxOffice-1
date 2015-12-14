using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class Ticket
	{
		// propriedades (prop... / propfull...)
		public int IdScreen { get; set; }

		public int Row { get; set; }

		public int Number { get; set; }

		public int IdMovie { get; set; }

		public DateTime Date { get; set; }

		public int? IdClient { get; set; }  // int? permite IdClient = null - Vou precisar de passar a usar IdClient.Value ou IdClient.HasValue
	}
}
