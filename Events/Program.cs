using System;

namespace Events
{
	class Program
	{
		static void Main(string[] args)
		{
			var carDealer = new CarDealer();
			var verstall = new Consumer("verstall");
			carDealer.NewCarInfo += verstall.NewCarIsHere; //subscribe the consumer to the event generator
			carDealer.NewCar("Maxi"); // This invokes the event that has the consumer message waiting
			var towey = new Consumer("towy");
			carDealer.NewCarInfo += towey.NewCarIsHere;
			carDealer.NewCar("Mini");
			carDealer.RecallInfo += verstall.CarMustBeRecalled;
			carDealer.RecallInfo += towey.CarMustBeRecalled;
			carDealer.RecallCar("Ford");
			carDealer.NewCarInfo -= verstall.NewCarIsHere;
			carDealer.NewCar("Pontiac");
			var tyreDealer = new TyreDealer();
			tyreDealer.NewTyreInfo += verstall.NewTyreReleased; //have same signatures
			tyreDealer.NewTyreInfo += towey.NewTyreReleased;
			tyreDealer.NewTyre("Michelin");
			Console.ReadLine();
		}
	}
}
