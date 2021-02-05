using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dan01
{
	class Car : IDrivable
	{
		public string Brand { get; set; }
		public double Speed { get; set; }

		public Car(string brand = "No Brand", double speed = 0)
		{
			Brand = brand;
			Speed = speed;
		}

		public void Drive() {
			Console.WriteLine($"The {Brand} Moves Forward at {Speed} MPH");
		}
		public void Brake() {
			Console.WriteLine($"The {Brand} Stops");
			Speed = 0;
		}
	}
}
