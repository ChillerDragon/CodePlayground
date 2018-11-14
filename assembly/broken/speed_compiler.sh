#!/bin/bash

while :
do
        clear
        echo "=== assembly speed compiler ==="
        echo "written by ChillerDragon"
        echo "executing compile.sh and binary: "
        ./compile.sh; ./haxx0r
        read -n1 -r -p "Press q to quit and anything else to rebuild..." key

        if [ "$key" = 'q' ]; then
                exit;
        fi
done
