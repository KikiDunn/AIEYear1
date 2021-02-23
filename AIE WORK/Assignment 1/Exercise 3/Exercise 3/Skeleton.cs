using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Skeleton class that inherits from monster
class Skeleton : Monster
{
	//default constructor
	public Skeleton()
	{
		//Set variables to default Skeleton values
		name = "Skeleton";
		strength = 100;
		health = 50;
	}
	//constructor that can take a weapon as parameter
	public Skeleton(Weapon weapon)
	{
		//Sets the Skeletons weapon to weapon being passed in
		this.weapon = weapon;
		//Set variables to Skeleton values
		name = "Skeleton";
		strength = 100;
		health = 50;
	}
	//print function that overrides the monster class function
	public override void Print()
	{
		Console.WriteLine(name);
		Console.WriteLine("Skeleton's health: " + health);
		Console.WriteLine("Skeleton's strength: " + strength);
		weapon.Print();
	}
}
