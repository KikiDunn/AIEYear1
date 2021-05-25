#include "Player.h"
#include <string.h>
Player::Player(char name[], int level) {
	strcpy_s(this->name, name);
	this->ID = level;
}
Player::Player() {}