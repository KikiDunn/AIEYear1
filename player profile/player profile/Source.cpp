#pragma once
#include <iostream>
#include "Player.h"
#include <string>
#include<fstream>
using namespace std;
int main() {
	Player* array = new Player[1000];
	string input = "";
	int input2 = 0;
	int inputcounter = 0;
	while (input != "q") {
		std::fstream file;
		file.open("data.dat", std::ios::in | std::ios::binary); 
		file.read((char*)&array, sizeof(Player)); 
		file.close();
		if (inputcounter == 10) {
			input = "done";
		}
		while (input != "done") {
			cout << "Add person name or done to finish:" << endl;
			cin >> input;
			cout << "\nperson age:" << endl;
			cout << input2;
			array[inputcounter].name = input;
			array[inputcounter].ID = input2;
			inputcounter++;
		}
	}
	delete[] array;
}