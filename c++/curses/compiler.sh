#!/bin/bash
clang++ *.cpp -c
clang++ *.o -lcurses -o test
