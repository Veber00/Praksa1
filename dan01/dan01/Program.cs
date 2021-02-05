using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dan01;


namespace dan01
{
	class Program
	{
		static void Main(string[] args)
		{
			Person John = new Person("John", "Muller", 28);
			Console.WriteLine(John.GetInfo());
			Student Matt = new Student("Matt", "Lord", 18, "Wall Street 28");
			Matt.Grade = 5;
			Console.WriteLine(Matt.GetInfo());

			Console.WriteLine("-------------------------");

			Car Ferrari = new Car("Ferrari", 160);
			Ferrari.Drive();
			Ferrari.Brake();

			Console.WriteLine("-------------------------");

			Shape[] shapes = { new Circle(4), new Rectangle(2, 5) };

			foreach (Shape s in shapes)
			{
				s.Info();
				Console.WriteLine("{0} Area : {1:f2}", s.Name, s.Area());
			}

			Console.WriteLine("-------------------------");
		}
	}
}
