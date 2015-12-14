using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class Session
	{
		// propriedades (prop... / propfull...)
		public int IdScreen { get; set; }

		public int IdMovie { get; set; }

		public DateTime Date { get; set; }

		public TimeSpan StartTime{ get; set; }

		// Construtor
		public Session()
		{
		}
	}
}
