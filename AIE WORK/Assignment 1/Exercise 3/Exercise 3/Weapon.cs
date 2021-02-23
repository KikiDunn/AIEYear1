using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Weapon
{
	//Default weapon values
	string name = "Unnamed";
	int damage = 1;
	float range = 1;
	string category = "sword";
	//default constructor
	public Weapon() { }
	//constructor that sets the weapon values based off parameters
	public Weapon(string name, int damage, float range, string category)
	{
		//sets the class values to parameter values
		this.name = name;
		this.damage = damage;
		this.range = range;
		this.category = category;
	}
	//print function to print weapon stats
	public void Print()
	{
		Console.WriteLine("Weapon Name: " + name);
		Console.WriteLine("Damage: " + damage);
		Console.WriteLine("Range: " + range);
		Console.WriteLine("Weapon Type: " + category);
	}
}
