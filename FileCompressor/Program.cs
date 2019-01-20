using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FileCompressor
{
	class Program
	{
		static void Main(string[] args)
		{
			var directory = @"C:\Users\Jeff\Source\Repos\FileReverser\FileCompressor\images";
			IEnumerable<string> fileNames = Directory.EnumerateFiles(directory, "*", SearchOption.TopDirectoryOnly);

			//fileNames.ToList<string>().ForEach(file => CompressFile(file));
			var zipFile = $"{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.zip";
			CreateZipFile(directory,zipFile);
		}

		private static void CreateZipFile(string directory, string zipFile)
		{
			FileStream zipStream = File.OpenWrite(zipFile);
			using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
			{
				IEnumerable<string> files = Directory.EnumerateFiles(directory, "*", SearchOption.TopDirectoryOnly);
				foreach(var file in files)
				{
					ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(file)); //Get the file name from full path
					using (FileStream inputStream = File.OpenRead(file))
					using (Stream outputStream = entry.Open())
					{
						inputStream.CopyTo(outputStream);
					}
				}
			}
		}

		private static void CompressFile(string file)
		{
			FileInfo fileInfo = new FileInfo(file);
			var compressedFile = fileInfo.FullName.Substring(0, fileInfo.FullName.Length - 5) + "compressed" + fileInfo.Extension;
			
			using (FileStream inputStream = File.OpenRead(file))
			{
				FileStream outputStream = File.OpenWrite(compressedFile);
				using (var compressStream = new DeflateStream(outputStream,CompressionMode.Compress))
				{
					inputStream.CopyTo(compressStream);
				}
			}
		}
	}

	
}
