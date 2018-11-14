#!/bin/bash

pos=0

function move {
    pos=$((pos + $1))
    echo "pos uodated to $pos"
}

while True;
do
    read -p "cmd: " inp
    if [ "$inp" == "q" ]
    then
        exit
    elif [ "$inp" == "a" ]
    then
        move -1
    elif [ "$inp" == "d" ]
    then
        move 1
    fi
done
