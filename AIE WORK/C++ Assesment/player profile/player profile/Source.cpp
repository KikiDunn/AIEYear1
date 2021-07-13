#pragma once
#include <iostream>
#include "Player.h"
#include<fstream>
#include <conio.h>
using namespace std;

static void sort(Player**& playerProfiles, int count) {
	bool sorted = false;
	while (!sorted) {
		sorted = true;
		for (int i = 0; i < count - 1; i++) {
			if (playerProfiles[i]->ID > playerProfiles[i + 1]->ID) {
				Player* temp = playerProfiles[i];
				playerProfiles[i] = playerProfiles[i + 1];
				playerProfiles[i + 1] = temp;
				sorted = false;
			}
		}
	}
}

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
		cin >> menu;
		if (strcmp(menu, "view") == 0) {
			for (int i = 0; i < count; i++) {
				std::cout << playerProfiles[i]->name << ", " << playerProfiles[i]->ID << std::endl;
			}
			
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
			sort(playerProfiles, count);
		}
		if (strcmp(menu, "search") == 0) {
			sort(playerProfiles, count);
			std::cout << "What player ID are you looking for: ";
			cin >> input2;
			int min = 0;
			int max = count;
			int searchHead = (int)count / 2;
			while (playerProfiles[searchHead]->ID != input2) {
				if (playerProfiles[searchHead]->ID > input2) {
					searchHead =  (int)(min + searchHead - 1) / 2;
				}
				else {
					searchHead = (int)(max + searchHead + 1) / 2;
				}
			}
			cout << "\nPlayer ID: " << playerProfiles[searchHead]->ID << " with name " << playerProfiles[searchHead]->name << "found" << endl;
		}
		if (strcmp(menu, "q") == 0) {
			break;
		}
		std::cout << "Press enter to continue..." << endl;
		_getch();
		system("cls");
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