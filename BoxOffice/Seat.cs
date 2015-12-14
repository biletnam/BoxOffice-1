using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class Seat
	{
		// propriedades (prop... / propfull...)
		public int IdScreen { get; set; }

		public int Row { get; set; }

		public int Number { get; set; }

		public bool Disability { get; set; }

		// Construtor
		public Seat()
		{
		}
	}
}
