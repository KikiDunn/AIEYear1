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
		//check if the file has been created yet
		if (File.Exists(@"..\..\..\text.txt"))
		{
			//reads the previous time from the file
			using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
			{
				previousTime = long.Parse(reader.ReadLine());
				reader.Close();
			}
			
		}
		else
		{
			//if the file doesn't exist sets the previous time to the current time
			previousTime = unixTime;
		}
		//starts writing to the file
		//if it doesn't exist this will make the file
		using (StreamWriter writer = new StreamWriter(@"..\..\..\text.txt"))
		{
			//writes the current time
			writer.WriteLine(unixTime);
			//writes the time that has elapsed since last time
			writer.WriteLine(unixTime - previousTime);
			writer.Close();
		}
	}
}
