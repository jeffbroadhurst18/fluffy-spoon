using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
	public class CarInfoEventArgs : EventArgs
	{
		public string Car;

		public CarInfoEventArgs(string car)
		{
			Car = car;
		}
	}

	public class CarDealer
	{
		public event EventHandler<CarInfoEventArgs> NewCarInfo; //an event that can occur.
		public event EventHandler<CarInfoEventArgs> RecallInfo; //an event that can occur.

		public void NewCar(string car)
		{
			Console.WriteLine($"Car Dealer announces new car: {car}");
			NewCarInfo?.Invoke(this, new CarInfoEventArgs(car)); //raises the event
		}

		public void RecallCar(string car)
		{
			Console.WriteLine($"Car Dealer announces car must be recalled: {car}");
			RecallInfo?.Invoke(this, new CarInfoEventArgs(car)); //raises the event 
		}
	}
}
