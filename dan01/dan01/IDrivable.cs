using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dan01
{
	interface IDrivable
	{
		double Speed { get; set; }
		void Drive();
		void Brake();
	}
}

