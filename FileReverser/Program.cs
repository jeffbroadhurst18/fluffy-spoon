using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReverser
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] newBytes = null; ;
			var stream = new FileStream(@"C:\Users\Jeff\Source\Repos\FileReverser\FileReverser\input.txt",
				FileMode.Open, FileAccess.Read, FileShare.Read);
			using (var reader = new StreamReader(stream))
			{
				while(!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					byte[] bytes = Encoding.UTF8.GetBytes(line);
					
					List<byte> newList = new List<byte>();
					for (int i=bytes.Length-1; i >= 0; i--)
					{
						newList.Add(bytes[i]);
					}
					newBytes = newList.ToArray();
				}
				
			}
			var reversedLine = Encoding.UTF8.GetString(newBytes);

			var outputStream = File.Create(@"C:\Users\Jeff\Source\Repos\FileReverser\FileReverser\reversed.txt");
			using (var writer = new StreamWriter(outputStream))
			{
				byte[] preamble = Encoding.UTF8.GetPreamble();
				outputStream.Write(preamble, 0, preamble.Length);
				writer.Write(reversedLine);
			}
		}
	}
}
