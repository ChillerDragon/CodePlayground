/*
#include <stdio.h>
#include <iostream>
int main()
{
    char ch;
    system("stty raw");//seting the terminal in raw mode
    while(1)
    {
        ch=getchar();
        if(ch=='~'){          //terminate or come out of raw mode on "~" pressed
            system("stty cooked");
            //while(1);//you may still run the code
            exit(0); //or terminate
        }
        printf("you pressed %c\n ",ch);  //write rest code here
    }
    
}
*/

#include <ncurses.h>
#include <unistd.h>  /* only for sleep() */

int kbhit(void)
{
    char ch = getchar();
    
    if (ch != ERR) {
        //ungetch(ch);
        return 1;
    } else {
        return 0;
    }
}

int main(void)
{
    initscr();
    
    cbreak();
    noecho();
    nodelay(stdscr, TRUE);
    
    scrollok(stdscr, TRUE);
    while (1) {
        if (kbhit()) {
            printw("Key pressed! It was: %d\n", getchar());
            refresh();
        } else {
            printw("No key pressed yet...\n");
            refresh();
            sleep(1);
        }
    }
}
