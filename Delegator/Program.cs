using System;

namespace Delegator
{
	class Program
	{
		private delegate int DoWork(int x, int y);

		static void Main(string[] args)
		{
			int x = 2;
			int y = 3;
			DoWork mult = new DoWork(Multiply);
			DoWork add = new DoWork(Add);
			Console.WriteLine($"Mult: {mult(x,y)}");
			Console.WriteLine($"Add: {add(x, y)}");

			//Alternative syntax
			mult = Multiply; //durectly assign the method to the delegate.
			add = Add;
			Console.WriteLine($"Mult: {mult(x, y)}");
			Console.WriteLine($"Add: {add(x, y)}");
			
			//Pass the operation in as a parmeter
			DoWork[] operations = { Multiply, Add };

			for (int i=0; i < operations.Length; i++)
			{
				ProcessAndDisplay(operations[i], 2, 3);
				ProcessAndDisplay(operations[i], 0, 5);
				ProcessAndDisplay(operations[i], 12, 7);
			}

			//Generic rather than defining delegate explicitly, last parameter is return type
			Func<int, int, int>[] funkyOperations = { Multiply, Add };
			for (int i = 0; i < funkyOperations.Length; i++)
			{
				ProcessAndDisplayFunc(funkyOperations[i], 12, 4);
				ProcessAndDisplayFunc(funkyOperations[i], 0, 15);
				ProcessAndDisplayFunc(funkyOperations[i], 2, 37);
			}
			Console.ReadLine();
		}

		private static void ProcessAndDisplay(DoWork action, int x, int y)
		{
			int result = action(x, y);
			Console.WriteLine($"DoWork {x} {action.Method.Name} {y} = {result}");
		}

		private static void ProcessAndDisplayFunc(Func<int,int,int> action, int x, int y)
		{
			int result = action(x, y);
			Console.WriteLine($"DoWork {x} {action.Method.Name} {y} = {result}");
		}

		private static int Multiply(int x, int y)
		{
			return x * y;
		}

		private static int Add(int x, int y)
		{
			return x + y;
		}
	}
}
