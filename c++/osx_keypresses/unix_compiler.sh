#!/bin/bash
while :
do
    clear
    echo "compiling TEST PROGRAMM (using clan++ with ncurses)"
    echo "========================================="
    clang++ *.cpp -c
    clang++ *.o -lcurses -o test
    mv *.o obj
    echo "========================================="
    echo "finished press any key to compile agian."
    read -n1
done
