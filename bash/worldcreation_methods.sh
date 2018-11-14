#!/bin/bash


pos=0
method=0
skin="#"
block="_"

function start {
echo "0 hardcodet"
echo "1 +="
echo "2 declare"
echo "3 []"
read -p "world creation method:" method


if [ $method -gt 0 ]
then
while :
do

    while true; do
        sleep 0.1
        clear
        rand=$(( $RANDOM % 10 + 60 ))
        echo "fps: $rand"


        stty -icanon time 0 min 0
        read -s input

        if [ "$input" = "a" ] && [ $pos -gt 0 ]; then
            pos=$((pos - 1))
        elif [ "$input" = "d" ]; then
            pos=$((pos + 1))
        elif [ "$input" = "x" ]; then
            stty sane
            start
        fi

        #creating world depenidng on method
        if [ $method -eq 1 ]
        then
            world=()
            world+="a"
            world+="b"
            world+="c"
            world+="d"
            world+="e"
#            world+="$block"
#            world+="$block"
#            world+="$block"
#            world+="$block"
#            world+="$block"
        elif [ $method -eq 2 ]
        then
            declare -a world=("$block" "$block" "$block" "$block" "$block")
        elif [ $method -eq 3 ]
        then
            world[0]="$block"
            world[1]="$block"
            world[2]="$block"
            world[3]="$block"
            world[4]="$block"


            world[7]="$block"
            world[8]="$block"
            world[9]="$block"
        fi

        world[$pos]="#"

#        echo "${world[0]}"
#        echo "${world[1]}"
#        echo "${world[2]}"
#        echo "${world[3]}"
#        echo "${world[4]}"
        c=0
        while [  $c -lt 20 ]; do
            printf "${world[$c]}"
            c=$((c + 1))
        done
#        printf "${world[@]}"
#        echo "${world[@]}"
        echo ""
        echo "method: $method pos: $pos"

        stty sane
    done
done
else #hardcodet medthod 0
    while true; do
        sleep 0.1
        clear
        rand=$(( $RANDOM % 10 + 60 ))
        echo "fps: $rand"

        stty -icanon time 0 min 0

        read -s input

        if [ "$input" = "a" ] && [ $pos -gt 0 ]; then
            pos=$((pos - 1))
        elif [ "$input" = "d" ]; then
            pos=$((pos + 1))
        elif [ "$input" = "x" ]; then
            stty sane
            start
        fi

        #print the world
        if [ $pos -eq 0 ]
        then
            echo "$skin$block$block$block$block"
        elif [ $pos -eq 1 ]
        then
            echo "$block$skin$block$block$block"
        elif [ $pos -eq 2 ]
        then
            echo "$block$block$skin$block$block"
        elif [ $pos -eq 3 ]
        then
            echo "$block$block$block$skin$block"
        elif [ $pos -eq 4 ]
        then
            echo "$block$block$block$block$skin"
        else
            echo "$block$block$block$block$block"
        fi
done
fi
}

start


