using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

class Program
{
	
	static void Main(string[] args)
	{
		//Create variable to store time written last time
		long previousTime;
		//get the current time
		long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		//check is 
		if (File.Exists(@"..\..\..\text.txt"))
		{
			using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
			{
				previousTime = long.Parse(reader.ReadLine());
				reader.Close();
			}
			
		}
		else
		{
			//File.Create(@"..\..\..\text.txt");
			previousTime = unixTime;
		}
				
		using (StreamWriter writer = new StreamWriter(@"..\..\..\text.txt"))
		{
			writer.WriteLine(unixTime);
			writer.WriteLine(unixTime - previousTime);
			writer.Close();
		}
	}
}
