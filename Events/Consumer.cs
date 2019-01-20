using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
	public class Consumer
	{
		private string _name;

		public Consumer(string name)
		{
			_name = name;
		}

		public void NewCarIsHere(object sender, CarInfoEventArgs e)
		{
			//This method fits the delegate pattern for an event.
			Console.WriteLine($"{_name}: car {e.Car} is new ");
		}

		public void CarMustBeRecalled(object sender, CarInfoEventArgs e)
		{
			Console.WriteLine($"{_name}: car {e.Car} must be recalled. ");
		}

		public void NewTyreReleased(object sender, TyreInfoEventArgs e)
		{
			Console.WriteLine($"{_name}: tyre {e.Tyre} has been released. ");
		}
	}
}
