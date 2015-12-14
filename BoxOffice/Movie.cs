using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
	public class Movie
	{
		// propriedades (prop... / propfull...)
		public int Id { get; set; }

		public string Title { get; set; }

		public int Runtime { get; set; }

		// contrutor
		public Movie()
		{
		}
	}
}
