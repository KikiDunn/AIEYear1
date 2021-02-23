using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Orc class that inherits from monster
class Orc : Monster
{
	//default constructor
	public Orc()
	{
		//Set variables to default Orc values
		name = "Orc";
		strength = 100;
		health = 500;
	}
	//constructor that can take a weapon as parameter
	public Orc(Weapon weapon)
	{
		//Sets the Orcs weapon to weapon being passed in
		this.weapon = weapon;
		//Set variables to Orc values
		name = "Orc";
		strength = 100;
		health = 500;
	}
	//print function that overrides the monster class function
	public override void Print()
	{
		Console.WriteLine(name);
		Console.WriteLine("Orc's health: " + health);
		Console.WriteLine("Orc's strength: " + strength);
		weapon.Print();
	}
}
