using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dan01
{

	public class Person
	{
		
		public string name;
		public string surname;
		public int age;
		private string address = "private";

		public Person()
		{
		}

		public Person(string _name, string _surname, int _age)
		{

			name = _name;
			surname = _surname;
			age = _age;
		}

		public Person(string _name, string _surname, int _age, string _address)
		{

			name = _name;
			surname = _surname;
			age = _age;
			Address = _address;
		}

		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		public virtual string GetInfo()
		{
			return ("Name " + name + " " + surname + ", Age: " + age + ", address: " + Address);
		}
	}
}