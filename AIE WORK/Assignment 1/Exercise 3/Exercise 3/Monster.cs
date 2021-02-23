using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Monster class that inherits from Actor
class Monster : Actor
{
	//default constructor
	public Monster()
	{
		//Set variables to default Monster values
		name = "unnammed monster";
		strength = 100;
		health = 500;
	}
	//constructor that can take a weapon as parameter
	public Monster(Weapon weapon)
	{
		//Sets the Monsters weapon to weapon being passed in
		this.weapon = weapon;
		//Set variables to Monster values
		name = "unnammed monster";
		strength = 100;
		health = 500;
	}
	//print function that overrides the actor class function
	public override void Print()
	{
		Console.WriteLine(name);
		Console.WriteLine("Health: " + health);
		Console.WriteLine("Strength: " + strength);
		weapon.Print();
	}
}
