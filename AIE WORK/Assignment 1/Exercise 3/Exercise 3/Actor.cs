using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Actor
{
	//Actor variables
	protected string name;
	protected int strength;
	protected int health;
	//Actor's weapon
	protected Weapon weapon;
	//Default constructor
	public Actor()
	{
		//Set variables to default values
		name = "unnammed";
		strength = 0;
		health = 100;
	}
	//constructor that takes a weapon as a parameter
	public Actor(Weapon weapon)
	{
		//Sets the actors weapon to weapon being passed in
		this.weapon = weapon;
		//sets actor variables
		name = "unnammed";
		strength = 0;
		health = 100;
	}
	//function that prints stats that can be overridden
	virtual public void Print()
	{
		Console.WriteLine("Name: " + name);
		Console.WriteLine("Health: " + health);
		Console.WriteLine("Strength: " + strength);
		weapon.Print();
	}
}

