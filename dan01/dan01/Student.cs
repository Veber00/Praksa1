using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dan01
{
	public class Student:Person
	{

		public Student(string name, string surname, int age, string address)
		
			:base(name, surname, age, address){
		}

		private int grade = 0;
		public int Grade
		{
			get { return grade; }
			set { grade = value; }
		}

		public override string GetInfo()
		{
			
			return ("Name " + name + " " + surname + ", Age: " + age + ", address: " + Address + ", grade: " + Grade);
		}
	}
}
