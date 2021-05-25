#pragma once
#include <iostream>
#include "Player.h"
#include<fstream>
#include <string.h>
using namespace std;
int main() {
	int size = 10;
	Player** playerProfiles = new Player*[size];
	for (int i = 0; i < size; i++) {
		playerProfiles[i] = new Player();
	}
	int count = 0;
	char input[30];
	int input2 = 0;
	int inputcounter = 0;
	std::fstream file;
	file.open("data.dat", std::ios_base::in | std::ios_base::binary);
	if (file.is_open())
	{
		while (!file.eof() && file.peek() != EOF)
		{
			
			file.read((char*)playerProfiles[count], sizeof(Player));
			
			//std::cout << playerProfiles[count]->name << ", " << playerProfiles[count]->ID << std::endl;
			count++;
			
		}
		file.close();

	}
	
	while (true) {
		char menu[10];
		cout << "+++++++Player Profiles+++++++\n" << "sort, view, add, search, or q to quit" << endl;
		if (strcmp(menu, "sort") == 0) {

		}
		if (strcmp(menu, "view") == 0) {

		}
		if (strcmp(menu, "add") == 0) {
			cout << "Add person name or done to finish:" << endl;
			cin >> input;
			cout << "\nperson id:" << endl;
			cin >> input2;
			strcpy_s(playerProfiles[count]->name, 30, input);
			playerProfiles[count]->ID = input2;
			count++;
		}
		if (strcmp(menu, "sort") == 0) {

		}
		if (strcmp(menu, "search") == 0) {

		}

	}
	file.open("data.dat", std::ios_base::out | std::ios_base::binary);
	if (file.is_open())
	{
		for (int i = 0; i < count; ++i)
		{
			file.write((char*)playerProfiles[i], sizeof(Player));
		}
		file.close();
	}
	delete[] playerProfiles;
	return 0;
}