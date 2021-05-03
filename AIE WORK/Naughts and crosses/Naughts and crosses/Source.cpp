#pragma once
#include <iostream>
#include <crtdbg.h>
#include <conio.h>

void blank()
{
	char game[3][10] = {
		{ ' ',' ',' ',' ',' ',' ', ' ',' ',' ', '\n' },
		{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\n' },
		{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\n' }
	};
}
int main() {
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	char input = ' ';
	char game[3][10] = {
		{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\n' },
		{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\n' },
		{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '\0' }
	};
	//char game[3][10];
	//game = board;
	blank();
	int positionx = 0;
	int positiony = 0;
	while (input != 'q') {
		system("cls");
		game[positionx][positiony] = '[';
		game[positionx][positiony + 2] = ']';
		std::cout << game[0];
		std::cout << game[1];
		std::cout << game[2];

		input = _getch();
		game[positionx][positiony] = ' ';
		game[positionx][positiony + 2] = ' ';
		switch (input) {
			case 'w':
				if (positionx > 0) {
					positionx = positionx - 1;
				}
				break;
			case 'a':
				if (positiony > 0) {
					positiony = positiony - 3;
				}
				break;
			case 's':
				if (positionx < 2) {
					positionx = positionx + 1;
				}
				break;
			case 'd':
				if (positiony < 6) {
					positiony = positiony + 3;
				}
				break;
		}
		
	}
 }
