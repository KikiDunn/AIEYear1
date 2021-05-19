#pragma once
#include <iostream>
#include "Person.h"
#include <string>
using namespace std;
int main() {
	Person* array = new Person[10];
	string input = "";
	int input2 = 0;
	int inputcounter = 0;
	while (input != "q") {
		if (inputcounter == 10) {
			input = "done";
		}
		while (input != "done") {
			cout << "Add person name or done to finish:" << endl;
			cin >> input;
			cout << "\nperson age:" << endl;
			cout << input2;
			array[inputcounter].name = input;
			array[inputcounter].age = input2;
			inputcounter++;
		}
	}
	delete[] array;
}