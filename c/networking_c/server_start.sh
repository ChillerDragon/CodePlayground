#!/bin/bash
#speedcompiler by ChillerDragon
#copyright ChillerDragon 2018

while :
do
	clear
    ./server
	read -n1 -r -p "Press q to quit and anything else to replay..." key

	if [ "$key" = 'q' ]; then
		exit;
	fi
done
