#pragma once
#include <iostream>
#include <crtdbg.h>
#include <conio.h>
int main() {
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	char input = ' ';
	char game[3][3] = { {' ', ' ', ' '},
						{' ', ' ', ' '},
						{' ', ' ', ' '}
	};
	bool win = false;
	int positionx = 0;
	int positiony = 0;
	char turn = 'X';
	int index;
	char blank[132] = { ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						'-', '-', '-', '|', '-', '-', '-', '|', '-', '-', '-', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						'-', '-', '-', '|', '-', '-', '-', '|', '-', '-', '-', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\n',
						' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', '\0' };
	char board[132];
	char lastGameState[132];
	strcpy_s(board, 132, blank);
	strcpy_s(lastGameState, 132, board);
	while (input != 'q') {
		system("cls");
		index = positiony * 48 + positionx * 4;
		if (turn == 'X') {
			board[index] = '\\';
			board[index + 2] = '/';
			board[index + 13] = 'X';
			board[index + 24] = '/';
			board[index + 26] = '\\';
		}
		else {
			board[index + 1] = '_';
			board[index + 12] = '/';
			board[index + 14] = '\\';
			board[index + 24] = '\\';
			board[index + 25] = '_';
			board[index + 26] = '/';
		}
		std::cout << board;
		input = _getch();
		
		switch (input) {
			case 'w':
				if (positiony > 0) {
					if (game[positiony - 1][positionx] == ' ') {
						positiony = positiony - 1;
					}
					else if (positiony == 2 && game[0][positionx] == ' ') {
						positiony = 0;
					}
					else if (positionx > 0 && game[positiony - 1][positionx - 1] == ' ') {
						positionx--;
						positiony--;
					}
					else if (positionx < 2 && game[positiony - 1][positionx + 1] == ' ') {
						positionx++;
						positiony--;
					}
					else if (positionx > 0 && positiony ==2 && game[0][positionx - 1] == ' ') {
						positionx--;
						positiony = 0;
					}
					else if (positionx < 2 && positiony == 2 && game[0][positionx + 1] == ' ') {
						positionx++;
						positiony = 0;
					}
					else if (positionx == 2 && positiony == 2 && game[0][0] == ' ') {
						positionx = 0;
						positiony = 0;
					}
					else if (positionx == 0 && positiony == 2 && game[0][2] == ' ') {
						positionx = 2;
						positiony = 0;
					}
				}
				break;
			case 'a':
				if (positionx > 0) {
					if (game[positiony][positionx-1] == ' ') {
						positionx = positionx - 1;
					}
					else if (positionx == 2 && game[positiony][0] == ' ') {
						positionx = 0;
					}
					else if (positiony > 0 && game[positiony - 1][positionx - 1] == ' ') {
						positionx--;
						positiony--;
					}
					else if (positiony < 2 && game[positiony + 1][positionx - 1] == ' ') {
						positionx--;
						positiony++;
					}
					else if (positiony > 0 && positionx == 2 && game[positiony - 1][0] == ' ') {
						positionx = 0;
						positiony--;
					}
					else if (positiony < 2 && positionx == 2 && game[positiony + 1][0] == ' ') {
						positionx = 0;
						positiony++;
					}
					else if (positionx == 2 && positiony == 0 && game[2][0] == ' ') {
						positionx = 0;
						positiony = 2;
					}
					else if (positionx == 2 && positiony == 2 && game[0][0] == ' ') {
						positionx = 0;
						positiony = 0;
					}
				}
				break;
			case 's':
				if (positiony < 2) {
					if (game[positiony + 1][positionx] == ' ') {
						positiony = positiony + 1;
					}
					else if (positiony == 0 && game[2][positionx] == ' ') {
						positiony = 2;
					}
					else if (positionx > 0 && game[positiony + 1][positionx - 1] == ' ') {
						positionx--;
						positiony++;
					}
					else if (positionx < 2 && game[positiony + 1][positionx + 1] == ' ') {
						positionx++;
						positiony++;
					}
					else if (positionx > 0 && positiony == 0 && game[2][positionx - 1] == ' ') {
						positionx--;
						positiony = 2;
					}
					else if (positionx < 2 && positiony == 0 && game[2][positionx + 1] == ' ') {
						positionx++;
						positiony = 2;
					}
					else if (positionx == 2 && positiony == 0 && game[2][0] == ' ') {
						positionx = 0;
						positiony = 0;
					}
					else if (positionx == 0 && positiony == 0 && game[2][2] == ' ') {
						positionx = 2;
						positiony = 2;
					}
				}
				break;
			case 'd':
				if (positionx < 2) {
					if (game[positiony][positionx + 1] == ' ') {
						positionx = positionx + 1;
					}
					else if (positionx == 0 && game[positiony][2] == ' ') {
						positionx = 2;
					}
					else if (positiony > 0 && game[positiony - 1][positionx + 1] == ' ') {
						positionx++;
						positiony--;
					}
					else if (positiony < 2 && game[positiony + 1][positionx + 1] == ' ') {
						positionx++;
						positiony++;
					}
					else if (positiony > 0 && positionx == 0 && game[positiony - 1][2] == ' ') {
						positionx = 2;
						positiony--;
					}
					else if (positiony < 2 && positionx == 0 && game[positiony + 1][2] == ' ') {
						positionx = 2;
						positiony++;
					}
					else if (positionx == 0 && positiony == 0 && game[2][2] == ' ') {
						positionx = 2;
						positiony = 2;
					}
					else if (positionx == 0 && positiony == 2 && game[0][2] == ' ') {
						positionx = 2;
						positiony = 0;
					}
				}
				break;
			case ' ':
				strcpy_s(lastGameState, 132, board);
				game[positiony][positionx] = turn;
				if (turn == 'X') {
					turn = 'O';
				}
				else {
					turn = 'X';
				}
				for (int i = 0; i < 3; i++) {
					if (game[i][0] != ' ') {
						if (game[i][0] == game[i][1] && game[i][0] == game[i][2]) {
							std::cout << "\nPlayer " << game[i][0] << " wins!" << std::endl;
							win = true;
							break;
						}
					}
					if(game[0][i] != ' '){
						if (game[0][i] == game[1][i] && game[0][i] == game[2][i]) {
							std::cout << "\nPlayer " << game[0][i] << " wins!" << std::endl;
							win = true;
							break;
						}
					}
					if (game[0][0] != ' ') {
						if (game[0][0] == game[1][1] && game[0][0] == game[2][2]) {
							std::cout << "\nPlayer " << game[0][0] << " wins!" << std::endl;
							win = true;
							break;
						}
					}
					if (game[0][2] != ' ') {
						if (game[0][2] == game[1][1] && game[0][2] == game[2][0]) {
							std::cout << "\nPlayer " << game[0][2] << " wins!" << std::endl;
							win = true;
							break;
						}
					}
				}

				break;

		}
		if (win == true) {
			_getch();
			strcpy_s(lastGameState, 132, blank);
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					game[i][j] = ' ';
				}
			}
			win = false;
		}
		strcpy_s(board, 132, lastGameState);
	}
 }
