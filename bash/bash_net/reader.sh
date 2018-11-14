#!/bin/bash

pos=0
IsExit=0

function set_pos {
    pos=$(($1))
    echo "pos uodated to $pos"
}

function get_pos {
    pos=`cat pos.txt`
}

function UpdatePos {
    get_pos
    set_pos $pos
}

function UserInp {
    read -p "cmd: " inp
    if [ "$inp" == "q" ]
    then
        IsExit=1
        echo "EXITING"
    elif [ "$inp" == "a" ]
    then
        echo "A PRESSED"
    elif [ "$inp" == "d" ]
    then
        echo "D PRESSED"
    fi
}

while True;
do
    UpdatePos &
    UserInp &
    if [ "$IsExit" == "1" ]
    then
        exit
    fi
    echo "exit: $IsExit"
    sleep 1
done
