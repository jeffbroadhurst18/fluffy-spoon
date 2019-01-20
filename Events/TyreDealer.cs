using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
	public class TyreInfoEventArgs : EventArgs
	{
		public string Tyre;

		public TyreInfoEventArgs(string tyre)
		{
			Tyre = tyre;
		}
	}
	//the arguments calss must inherit from EventArgs
	public class TyreDealer
	{
		public event EventHandler<TyreInfoEventArgs> NewTyreInfo;

		public void NewTyre(string tyre)
		{
			Console.WriteLine($"Tyre Dealer releases new tyre: {tyre}");
			NewTyreInfo?.Invoke(this, new TyreInfoEventArgs(tyre));
		}
	}
}
