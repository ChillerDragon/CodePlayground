#!/bin/bash
#speedcompiler by ChillerDragon
#copyright ChillerDragon 2018

while :
do
	clear
	echo "=== chiller speed compiler ==="
	echo "written by ChillerDragon"
    gcc client.c -o client;
    gcc server.c -o server;
#    ./server
	read -n1 -r -p "Press q to quit and anything else to rebuild..." key

	if [ "$key" = 'q' ]; then
		exit;
	fi
done
