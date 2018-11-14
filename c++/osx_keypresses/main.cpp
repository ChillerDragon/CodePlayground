#include <termios.h>
#include <unistd.h>
#include <fcntl.h>
#include <curses.h>
#include <iostream>
#include <fstream>
#include <stdlib.h>
#include <stdio.h>
#include <cstdlib>

int Tick = 0;



void KeyPresses()
{
    char key = getch();
    if (key == 97)
    {
        std::cout << "A" << Tick << std::endl;
    }
    else if (key == 'd')
    {
        std::cout << "D" << Tick << std::endl;
        Tick = 0;
    }
    else
    {
        if (key != -1)
        {
            std::cout << key << std::endl;
        }
    }
}

int main ()
{
    while (true)
    {
        Tick++;
        KeyPresses();
    }
}
