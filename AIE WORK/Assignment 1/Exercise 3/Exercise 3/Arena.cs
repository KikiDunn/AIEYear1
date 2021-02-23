using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arena
{
	//Instanciate weapons and actors array
	Weapon[] weapons = new Weapon[3];
	Actor[] actors = new Actor[3];
	public Arena()
	{
		//Initialise both arrays
		weapons[0] = new Weapon("Makeshift Spear", 5, 10f, "spear");
		weapons[1] = new Weapon("Rusty Sword", 10, 5f, "sword");
		weapons[2] = new Weapon("Choppa", 50, 7.5f, "heavy sword");
		actors[0] = new Goblin(weapons[0]);
		actors[1] = new Skeleton(weapons[1]);
		actors[2] = new Orc(weapons[2]);
	}
	//Method to run all the objects' print() function in the actors arrays
	public void PrintAll()
	{
		for (int i = 0; i < actors.Length; i++)
		{
			actors[i].Print();
		}
	}
}
