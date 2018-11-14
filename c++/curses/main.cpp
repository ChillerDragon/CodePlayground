#include<curses.h>
#include<stdio.h>
#include <unistd.h>
#include <iostream>

/*
int main(){
    int sec=0,min=0;
    
    initscr();
    refresh();
    while(true){
        if(true){
            mvaddstr(14,15,"  Elpmet's clock");
            standend();
            //attron(A_BOLD);
            mvaddstr( 8,15,"= = = = = = = = = = =");
            mvaddstr( 9,14,"|");mvaddstr( 9,36,"| yolo");
            mvaddstr(10,14,"|");mvaddstr(10,36,"| yolo");
            mvaddstr(11,14,"|");mvaddstr(11,36,"| yolo");
            mvaddstr(12,15,"= = = = = = = = = = =");
            move(23,79);
            standend();
            refresh();
        }
        while(sec<60){
            move(10,22);
            printw("%2d:%2d.",min,sec++);
            move(23,79);
            refresh();
            usleep(1000);
        }
        sec=0;
        ++min;
    }
}
 

int main ()
{
    std::cout << "ooooooooooooooooooooo" << std::endl
    << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
       << "oooooooooooooooooooooooooo" << std::endl
    << "oooooooooooooooooooooooooo" << std::endl;
    
    
    //initscr();
    //refresh();
    while (true)
    {
 
        mvaddstr(3,3,"Hello curel world");
        standend();
        move(3,3);
        standend();
        refresh();
        move(3,4);
        //printw("");
        move(20,15); //den cursor den man dann immer sieht
        standend();
        refresh();
 
        
        move(2,2);
        printw("yolo");
        refresh();
        
        usleep(1000);
    }
}
 */



int main ()
{

while (true)
{
    initscr();
    refresh();
    move(2,0);
    printw("___________________");
    move(2,5);
    printw("x");
    move(20,10);
    //endwin();
    usleep(1000);
}




}
