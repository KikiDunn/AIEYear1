using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//goblin class that inherits from monster
class Goblin : Monster
{
	//default constructor
	public Goblin()
	{
		//Set variables to default goblin values
		name = "Goblin";
		strength = 10;
		health = 50;
	}
	//constructor that can take a weapon as parameter
	public Goblin(Weapon weapon)
	{
		//Sets the goblins weapon to weapon being passed in
		this.weapon = weapon;
		//Set variables to goblin values
		name = "Goblin";
		strength = 10;
		health = 50;
	}
	//print function that overrides the monster class function
	public override void Print()
	{
		Console.WriteLine(name);
		Console.WriteLine("Goblin's health: " + health);
		Console.WriteLine("Goblin's strength: " + strength);
		weapon.Print();
	}
}
